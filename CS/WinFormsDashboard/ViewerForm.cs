using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.DashboardWin;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.Sql;
using System.Xml.Linq;
using DevExpress.DataAccess.Native.Sql;

namespace WinFormsDashboard {
    public partial class ViewerForm : DevExpress.XtraEditors.XtraForm {
        public ViewerForm() {
            InitializeComponent();
        }
        
        private void ViewerForm_Load(object sender, EventArgs e) {
            dashboardViewer1.LoadDashboard("TestDashboard.xml");
        }

        List<DashboardSqlDataSource> dataSources;
        private void dashboardViewer1_DashboardLoaded(object sender, DashboardLoadedEventArgs e) {
            dataSources = e.Dashboard.DataSources.OfType<DashboardSqlDataSource>().ToList();
            foreach (var query in dataSources.SelectMany(ds => ds.Queries.Select(q => new { DataSource = ds, Query = q }))) {
                var ods = new DashboardObjectDataSource("ods|" + query.DataSource.ComponentName + "|" + query.Query.Name);
                e.Dashboard.DataSources.Add(ods);
                foreach (var item in e.Dashboard.Items.OfType<DataDashboardItem>().Where(i => i.DataSource == query.DataSource && i.DataMember == query.Query.Name)) {
                    item.DataMember = "";
                    item.DataSource = ods;
                }
                foreach (var parameter in e.Dashboard.Parameters.Select(p => p.LookUpSettings).OfType<DynamicListLookUpSettings>().Where(p => p.DataSource == query.DataSource && p.DataMember == query.Query.Name)) {
                    parameter.DataMember = "";
                    parameter.DataSource = ods;
                }
            }
        }

        private void dashboardViewer1_DataLoading(object sender, DataLoadingEventArgs e) {
            if (e.DataSourceName.StartsWith("ods|")) {
                string[] names = e.DataSourceName.Split("|".ToCharArray());
                DashboardSqlDataSource dataSource = dataSources.First(ds => ds.ComponentName == names[1]);
                SqlQuery query = dataSource.Queries.First(q => q.Name == names[2]);

                XElement dsXML = dataSource.SaveToXml();
                SqlDataSource sqlDS = new SqlDataSource();
                sqlDS.LoadFromXml(dsXML);
                sqlDS.ConnectionName = "Connection";
                sqlDS.Fill(query.Name);

                ResultSet rSet = ((IListSource)sqlDS).GetList() as ResultSet;
                ResultTable rTable = rSet.Tables.First(t => t.TableName == query.Name);

                if (query.Name == "Invoices") {
                    var dt = ConvertResultTableToDataTable(rTable);
                    for (int i = dt.Rows.Count - 1; i >= 0; i--) {
                        if (((DateTime)dt.Rows[i]["OrderDate"]).Year < 2016)
                            dt.Rows.RemoveAt(i);
                    }
                    e.Data = dt;
                }
                else
                    e.Data = rTable;
            }
        }
        DataTable ConvertResultTableToDataTable(ResultTable resultTable) {
            DataTable dataTable = new DataTable(resultTable.TableName);
            resultTable.Columns.ForEach(col => dataTable.Columns.Add(new DataColumn(col.Name, col.PropertyType)));
            foreach (ResultRow resultRow in resultTable) {
                DataRow newRow = dataTable.NewRow();
                foreach (var column in resultTable.Columns) {
                    newRow[column.Name] = column.GetValue(resultRow);
                }
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }
    }
}
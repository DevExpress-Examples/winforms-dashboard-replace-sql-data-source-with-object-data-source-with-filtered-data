Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.DashboardWin
Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.Sql
Imports System.Xml.Linq
Imports DevExpress.DataAccess.Native.Sql

Namespace WinFormsDashboard
	Partial Public Class ViewerForm
		Inherits DevExpress.XtraEditors.XtraForm

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub ViewerForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			dashboardViewer1.LoadDashboard("TestDashboard.xml")
		End Sub

		Private dataSources As List(Of DashboardSqlDataSource)
		Private Sub dashboardViewer1_DashboardLoaded(ByVal sender As Object, ByVal e As DashboardLoadedEventArgs) Handles dashboardViewer1.DashboardLoaded
			dataSources = e.Dashboard.DataSources.OfType(Of DashboardSqlDataSource)().ToList()
			For Each query In dataSources.SelectMany(Function(ds) ds.Queries.Select(Function(q) New With {Key .DataSource = ds, Key .Query = q}))
				Dim ods = New DashboardObjectDataSource("ods|" & query.DataSource.ComponentName & "|" & query.Query.Name)
				e.Dashboard.DataSources.Add(ods)
                For Each item In e.Dashboard.Items.OfType(Of DataDashboardItem)().Where(Function(i) i.DataSource.Equals(query.DataSource) AndAlso i.DataMember = query.Query.Name)
                    item.DataMember = ""
                    item.DataSource = ods
                Next item
                For Each parameter In e.Dashboard.Parameters.Select(Function(p) p.LookUpSettings).OfType(Of DynamicListLookUpSettings)().Where(Function(p) p.DataSource.Equals(query.DataSource) AndAlso p.DataMember = query.Query.Name)
                    parameter.DataMember = ""
                    parameter.DataSource = ods
                Next parameter
            Next query
		End Sub

		Private Sub dashboardViewer1_DataLoading(ByVal sender As Object, ByVal e As DataLoadingEventArgs) Handles dashboardViewer1.DataLoading
			If e.DataSourceName.StartsWith("ods|") Then
				Dim names() As String = e.DataSourceName.Split("|".ToCharArray())
				Dim dataSource As DashboardSqlDataSource = dataSources.First(Function(ds) ds.ComponentName = names(1))
				Dim query As SqlQuery = dataSource.Queries.First(Function(q) q.Name = names(2))

				Dim dsXML As XElement = dataSource.SaveToXml()
				Dim sqlDS As New SqlDataSource()
				sqlDS.LoadFromXml(dsXML)
				sqlDS.ConnectionName = "Connection"
				sqlDS.Fill(query.Name)

				Dim rSet As ResultSet = TryCast(DirectCast(sqlDS, IListSource).GetList(), ResultSet)
				Dim rTable As ResultTable = rSet.Tables.First(Function(t) t.TableName = query.Name)

				If query.Name = "Invoices" Then
					Dim dt = ConvertResultTableToDataTable(rTable)
					For i As Integer = dt.Rows.Count - 1 To 0 Step -1
						If CDate(dt.Rows(i)("OrderDate")).Year < 2016 Then
							dt.Rows.RemoveAt(i)
						End If
					Next i
					e.Data = dt
				Else
					e.Data = rTable
				End If
			End If
		End Sub
		Private Function ConvertResultTableToDataTable(ByVal resultTable As ResultTable) As DataTable
			Dim dataTable As New DataTable(resultTable.TableName)
			resultTable.Columns.ForEach(Sub(col) dataTable.Columns.Add(New DataColumn(col.Name, col.PropertyType)))
			For Each resultRow As ResultRow In resultTable
				Dim newRow As DataRow = dataTable.NewRow()
				For Each column In resultTable.Columns
					newRow(column.Name) = column.GetValue(resultRow)
				Next column
				dataTable.Rows.Add(newRow)
			Next resultRow
			Return dataTable
		End Function
	End Class
End Namespace
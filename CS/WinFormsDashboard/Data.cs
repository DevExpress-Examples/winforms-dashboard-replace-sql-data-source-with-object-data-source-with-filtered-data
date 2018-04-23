using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;

namespace DataLibrary
{
    public class DataItem
    {
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public decimal Target { get; set; }
        public string SalesPersons { get; set; }
        public string Category { get; set; }
        public string Product { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Image CategoryImage { get; set; }
    }

    public class DataProvider
    {
        public static string DataSourceName { get { return "Default Datasource"; } }

        public static List<DataItem> GetRandomDataList( int rowCount )
        {  
            List<DataItem> list = new List<DataItem>();
            string[] salesPersons = { "Andrew Fuller", "Michael Suyama", "Robert King", "Nancy Davolio", "Margaret Peacock", "Laura Callahan", "Steven Buchanan", "Janet Leverling" };
            double[] lattitudes = {45.806064,36.247343,39.439133,45.462800,29.232212,33.287802,44.905274,40.866558  };
            double[] longitudes = { -123.536470, -108.394521, -76.929677, -85.279286, -81.587880, -117.535146, -68.843740, -111.998036 };

            string[] catergories = new string[] { null,  "Category 1", "Category 2", "Category 3", "Category 4" };
            string[] products = new string[] { "Aaa", "Bbb", "Ccc", "Ddd", "Eee", "Fff" };
            string[] countriesAll = new string[] {"French Guiana","Afghanistan","Angola","Albania","United Arab Emirates","Argentina","Armenia","Fr. S. Antarctic Lands","Australia","Austria","Azerbaijan","Burundi","Belgium","Benin","Burkina Faso","Bangladesh","Bulgaria","Bahamas","Bosnia and Herz.","Belarus","Belize","Bolivia","Brazil","Brunei","Bhutan","Botswana","Central African Rep.","Canada","Switzerland","Chile","China","Cote d'Ivoire","Cameroon","Dem. Rep. Congo","Congo","Colombia","Costa Rica","Cuba","Czech Rep.","Germany","Djibouti","Denmark","Dominican Rep.","Algeria","Ecuador","Egypt","Eritrea","Spain","Estonia","Ethiopia","Finland","Fiji","Falkland Is.","Gabon","United Kingdom","Georgia","Ghana","Guinea","Gambia","Guinea-Bissau","Eq. Guinea","Greece","Greenland","Guatemala","Guyana","Honduras","Croatia","Haiti","Hungary","Indonesia","India","Ireland","Iran","Iraq","Iceland","Israel","Italy","Jamaica","Jordan","Japan","Kazakhstan","Kenya","Kyrgyzstan","Cambodia","Korea","Kosovo","Kuwait","Lao PDR","Lebanon","Liberia","Libya","Sri Lanka","Lesotho","Lithuania","Luxembourg","Latvia","Morocco","Moldova","Madagascar","Mexico","Macedonia","Mali","Myanmar","Montenegro","Mongolia","Mozambique","Mauritania","Malawi","Malaysia","Namibia","New Caledonia","Niger","Nigeria","Nicaragua","Netherlands","Norway","Nepal","New Zealand","Oman","Pakistan","Panama","Peru","Philippines","Papua New Guinea","Poland","Puerto Rico","Dem. Rep. Korea","Portugal","Paraguay","Palestine","Qatar","Romania","Rwanda","W. Sahara","Saudi Arabia","Sudan","S. Sudan","Senegal","Solomon Is.","Sierra Leone","El Salvador","Serbia","Suriname","Slovakia","Slovenia","Sweden","Swaziland","Syria","Chad","Togo","Thailand","Tajikistan","Turkmenistan","Timor-Leste","Trinidad and Tobago","Tunisia","Turkey","Taiwan","Tanzania","Uganda","Ukraine","Uruguay","United States","Uzbekistan","Venezuela","Vietnam","Vanuatu","Yemen","South Africa","Zambia","Zimbabwe","Russia","Cyprus","Somalia","France"};
            string[] countriesEurope = new string[] { "Albania", "Aland", "Andorra", "Austria", "Belgium", "Bulgaria", "Bosnia and Herz.", "Belarus", "Switzerland", "Czech Rep.", "Germany", "Denmark", "Spain", "Estonia", "Finland", "France", "Faeroe Is.", "United Kingdom", "Guernsey", "Greece", "Croatia", "Hungary", "Isle of Man", "Ireland", "Iceland", "Italy", "Jersey", "Kosovo", "Liechtenstein", "Lithuania", "Luxembourg", "Latvia", "Monaco", "Moldova", "Macedonia", "Malta", "Montenegro", "Netherlands", "Norway", "Poland", "Portugal", "Romania", "San Marino", "Serbia", "Slovakia", "Slovenia", "Sweden", "Ukraine", "Vatican", "Russia" };
            Random r = new Random();

            DateTime date = DateTime.Today;
            for (int i = 0; i < rowCount; i++)
            {
                date = date.AddDays(r.Next(8));
                decimal total = 3500 - r.Next( 1000 );
                int categoryIndex = r.Next(catergories.Length);
                int salesPersonIndex = r.Next( salesPersons.Length );
                list.Add(new DataItem() {
 
                    OrderDate = date, 
                    Total =  total, 
                    Target = total + r.Next( 1000),
                    Category = catergories[categoryIndex], 
                    Product = GetNext(r, products),
                    SalesPersons = salesPersons[ salesPersonIndex ],
                    Latitude = lattitudes[salesPersonIndex],
                    Longitude = longitudes[salesPersonIndex],
                    Country = GetNext(r, countriesAll)
                });
            }
            
            return list;
        }

        

        static string GetNext(Random r, string[] sourceStr)
        {
            return sourceStr[r.Next(sourceStr.Length)];
        }

        public static List<DataItem> GetStaticDataList()
        {
            List<DataItem> list = new List<DataItem>();
            DateTime baseDate = DateTime.Today;
            list.Add(new DataItem() { OrderDate = baseDate, Total = 100, Category = "", Product = "" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(1), Total = 90, Category = "", Product = "" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(2), Total = 160, Category = "", Product = "" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(3), Total = 70, Category = "", Product = "" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(4), Total = 130, Category = "", Product = "" });

            list.Add(new DataItem() { OrderDate = baseDate, Total = 120, Category = "Bbb", Product = "Z" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(1), Total = 90, Category = "Bbb", Product = "Z" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(2), Total = 120, Category = "Bbb", Product = "Y" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(3), Total = 50, Category = "Bbb", Product = "X" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(4), Total = 100, Category = "Bbb", Product = "Z" });

            list.Add(new DataItem() { OrderDate = baseDate, Total = 90, Category = "Ccc", Product = "Y" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(1), Total = 40, Category = "Ccc", Product = "Z" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(2), Total = 100, Category = "Ccc", Product = "X" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(3), Total = 170, Category = "Ccc", Product = "X" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(4), Total = 100, Category = "Ccc", Product = "Z" });

            baseDate = baseDate.AddYears(1);
            list.Add(new DataItem() { OrderDate = baseDate, Total = 140, Category = "", Product = "" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(1), Total = 30, Category = "", Product = "" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(2), Total = 110, Category = "", Product = "" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(3), Total = 50, Category = "", Product = "" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(4), Total = 90, Category = "", Product = "" });

            list.Add(new DataItem() { OrderDate = baseDate, Total = 120, Category = "Bbb", Product = "Y" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(1), Total = 90, Category = "Bbb", Product = "Y" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(2), Total = 40, Category = "Bbb", Product = "X" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(3), Total = 30, Category = "Bbb", Product = "Z" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(4), Total = 120, Category = "Bbb", Product = "Z" });

            list.Add(new DataItem() { OrderDate = baseDate, Total = 190, Category = "Ccc", Product = "Z" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(1), Total = 140, Category = "Ccc", Product = "Y" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(2), Total = 140, Category = "Ccc", Product = "X" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(3), Total = 60, Category = "Ccc", Product = "Y" });
            list.Add(new DataItem() { OrderDate = baseDate.AddMonths(4), Total = 130, Category = "Ccc", Product = "X" });


            return list;
        }

        public static DataTable GetDataTable(int rowCount)
        {
            DataTable dt = CreateTable();
            foreach (DataItem d in GetRandomDataList(rowCount))
                dt.Rows.Add(new object[] { d.OrderDate, d.Total, d.Target, d.SalesPersons, d.Category, d.Product, d.Country });
            return dt;
        }

        private static DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("OrderDate", typeof(DateTime));
            dt.Columns.Add("Total", typeof(decimal));
            dt.Columns.Add("Target", typeof(decimal));
            dt.Columns.Add("SalesPerson", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Product", typeof(string));
            dt.Columns.Add("Country", typeof(string));
            return dt;
        }
    }
}



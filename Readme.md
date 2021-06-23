<!-- default file list -->
*Files to look at*:

* [ViewerForm.cs](./CS/WinFormsDashboard/ViewerForm.cs) (VB: [ViewerForm.vb](./VB/WinFormsDashboard/ViewerForm.vb))
<!-- default file list end -->
# Dashboard for WinForms - How to Replace the Dashboard Sql Data Source with the Dashboard Object Data Source


The [DashboardSqlDataSource](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardSqlDataSource) has [two modes for data retrieval](https://docs.devexpress.com/Dashboard/17083):

* Direct database connection (Server mode)
* In-memory data processing (Client mode)

The first approach works if you configure the data source with the [Query Builder](https://docs.devexpress.com/Dashboard/16152). You can handle the [CustomFilterExpression](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.CustomFilterExpression) event to filter data.

If you use a custom SQL query or a stored procedure, only **Client Data Processing Mode** is available. This example demonstrates how to get data from a database. filter the data in code and pass it to the [DashboardObjectDataSource](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardObjectDataSource).

To accomplish this task, handle the [DashboardLoaded](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.DashboardLoaded) event and replace SQL queries with a new [DashboardObjectDataSource](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardObjectDataSource). Subsequently handle the [DataLoading](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.DataLoading) event to provide data to the new object data source. 

![screenshot](/images/screenshot.png)

## More Examples
* [T347509: How to get data from the Dashboard DataSource and convert it to DataTable](https://www.devexpress.com/Support/Center/Question/Details/T347509) 



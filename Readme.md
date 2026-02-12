<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128581309/17.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T556647)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [ViewerForm.cs](./CS/WinFormsDashboard/ViewerForm.cs) (VB: [ViewerForm.vb](./VB/WinFormsDashboard/ViewerForm.vb))
<!-- default file list end -->
# How to replace DashboardSqlDataSource with DashboardObjectDataSource with filtered data


<p><a href="https://documentation.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardSqlDataSource.class">DashboardSqlDataSource</a> allows requesting data in two ways:<br>1. Direct database connection: <a href="https://documentation.devexpress.com/Dashboard/17083/Main-Features/Connecting-to-a-Data-Source/Data-Processing-Modes">Server Mode</a>.<br>2. In-memory data processing: <a href="https://documentation.devexpress.com/Dashboard/17083/Main-Features/Connecting-to-a-Data-Source/Data-Processing-Modes">Client Mode</a>.<br><br>The first approach works if you configure the data source using the <a href="https://documentation.devexpress.com/Dashboard/16152/Creating-Dashboards/Creating-Dashboards-in-the-WinForms-Designer/Providing-Data/SQL-Data-Source/Working-with-Data/Using-the-Query-Builder">Query Builder</a>. In this case, it is possible to add a custom filter expression to filter requested data using the <a href="https://documentation.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.CustomFilterExpression.event">CustomFilterExpression</a> event.<br>If you load data using a custom SQL query or a stored procedure, only <a href="https://documentation.devexpress.com/Dashboard/17083/Main-Features/Connecting-to-a-Data-Source/Data-Processing-Modes">Client Data Processing Mode</a> is supported. This example demonstrates how to filter data requested from a database manually and pass it to a dashboard as <a href="https://documentation.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardObjectDataSource.members">DashboardObjectDataSource</a>.<br>To accomplish this task, handle the <a href="https://documentation.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.DashboardLoaded.event">DashboardLoaded</a> event and replace the target <a href="https://documentation.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardSqlDataSource.members">DashboardSqlDataSource</a> queries with new <a href="https://documentation.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardObjectDataSource.members">DashboardObjectDataSource</a><u>s</u>.<br>Then, handle the <a href="https://documentation.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.DataLoading.event">DataLoading</a> event to provide data to the new object data sources. To learn how to request data using DashboardSqlDataSource, refer to the <a href="https://www.devexpress.com/Support/Center/p/T347509">T347509: How to get data from the Dashboard DataSource and convert it to DataTable</a> thread. <br> </p>

<br/>


<!-- feedback -->
## Does This Example Address Your Development Requirements/Objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-dashboard-replace-sql-data-source-with-object-data-source-with-filtered-data&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-dashboard-replace-sql-data-source-with-object-data-source-with-filtered-data&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->

<!-- default file list -->
*Files to look at*:

* [BO.cs](./CS/WebSite/App_Code/BO.cs) (VB: [BO.vb](./VB/WebSite/App_Code/BO.vb))
* [ClientScripts.js](./CS/WebSite/ClientScripts.js) (VB: [ClientScripts.js](./VB/WebSite/ClientScripts.js))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
<!-- default file list end -->
# How to implement series point editing via the ASPxPopupControl


<p>This example illustrates how to implement series point editing via the ASPxPopupControl. For this, the <a href="http://documentation.devexpress.com/#XtraCharts/DevExpressXtraChartsWebScriptsASPxClientWebChartControl_ObjectSelectedtopic"><u>ASPxClientWebChartControl.ObjectSelected Event</u></a> is handled. In this event handler a series point argument and value are assigned to editors (ASPxTextBox and ASPxTimeEdit in this example) within a popup, and this popup is displayed via the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxPopupControlScriptsASPxClientPopupControl_Showtopic"><u>ASPxClientPopupControl.Show Method</u></a><u>.</u> When the editing is finished (in the "Ok" button click event handler), modified values are passed to the server side (via the <a href="http://documentation.devexpress.com/#XtraCharts/DevExpressXtraChartsWebScriptsASPxClientWebChartControl_PerformCallbacktopic"><u>ASPxClientWebChartControl.PerformCallback Method</u></a>) to update the underlying datasource to which the WebChartControl is bound.</p><p>Also, please note the way, in which time values in Local format are converted to UTC format and to string format which can be parsed on the server side via the <a href="http://msdn.microsoft.com/en-us/library/9xk1h71t.aspx"><u>Convert.ToDateTime Method</u></a>. For this, the _aspxToUtcTime and _aspxGetInvariantDateTimeString methods are used.</p><p><strong>See also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/E2466">How to post data back to the database when editing series points in the WebChartControl</a></p>

<br/>



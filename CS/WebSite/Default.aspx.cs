using System;
using System.Data;
using System.Globalization;
using DevExpress.XtraCharts;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        BindChartToData();
    }

    private void BindChartToData() {
        // Create a series
        Series series = new Series("Series", ViewType.Line);

        series.ArgumentScaleType = ScaleType.DateTime;
        series.ValueScaleType = ScaleType.Numerical;

        ((LineSeriesView)series.View).LineMarkerOptions.Size = 20;

        // Bind series to data
        series.DataSource = ManualDataSet.RetrieveDataCache().Tables[0];
        series.ArgumentDataMember = "MyDateTime";
        series.ValueDataMembers.AddRange(new string[] { "MyData" });
        WebChartControl1.Series.Add(series);

        // Adjust X axis options
        ((XYDiagram)WebChartControl1.Diagram).AxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
        ((XYDiagram)WebChartControl1.Diagram).AxisX.DateTimeOptions.FormatString = "HH:mm:ss";
        ((XYDiagram)WebChartControl1.Diagram).AxisX.Label.Staggered = true;

        ((XYDiagram)WebChartControl1.Diagram).AxisX.DateTimeMeasureUnit = DateTimeMeasurementUnit.Hour;
        //((XYDiagram)WebChartControl1.Diagram).AxisX.GridSpacingAuto = false;
        //((XYDiagram)WebChartControl1.Diagram).AxisX.GridSpacing = 1;

        WebChartControl1.DataBind();
    }

    protected void WebChartControl1_CustomCallback(object sender, DevExpress.XtraCharts.Web.CustomCallbackEventArgs e) {
        string[] parameters = e.Parameter.Split(';');
        DateTime originalArgument = Convert.ToDateTime(hfOriginalArgument.Value, CultureInfo.InvariantCulture);
        DateTime argument = Convert.ToDateTime(parameters[0], CultureInfo.InvariantCulture);
        double value = Convert.ToDouble(parameters[1]);
        DataTable table = ManualDataSet.RetrieveDataCache().Tables[0];
        
        for (int i = 0; i < table.Rows.Count; i++) {
            if (Convert.ToDateTime(table.Rows[i]["MyDateTime"]) == originalArgument) {
                table.Rows[i]["MyDateTime"] = argument;
                table.Rows[i]["MyData"] = value;
                break;
            }
        }
    }

}
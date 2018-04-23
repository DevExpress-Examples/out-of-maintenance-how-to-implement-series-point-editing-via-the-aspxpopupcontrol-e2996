Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Globalization
Imports DevExpress.XtraCharts

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		BindChartToData()
	End Sub

	Private Sub BindChartToData()
		' Create a series
		Dim series As New Series("Series", ViewType.Line)

		series.ArgumentScaleType = ScaleType.DateTime
		series.ValueScaleType = ScaleType.Numerical

		CType(series.View, LineSeriesView).LineMarkerOptions.Size = 20

		' Bind series to data
		series.DataSource = ManualDataSet.RetrieveDataCache().Tables(0)
		series.ArgumentDataMember = "MyDateTime"
		series.ValueDataMembers.AddRange(New String() { "MyData" })
		WebChartControl1.Series.Add(series)

		' Adjust X axis options
		CType(WebChartControl1.Diagram, XYDiagram).AxisX.DateTimeOptions.Format = DateTimeFormat.Custom
		CType(WebChartControl1.Diagram, XYDiagram).AxisX.DateTimeOptions.FormatString = "HH:mm:ss"
		CType(WebChartControl1.Diagram, XYDiagram).AxisX.Label.Staggered = True

		CType(WebChartControl1.Diagram, XYDiagram).AxisX.DateTimeMeasureUnit = DateTimeMeasurementUnit.Hour
		'((XYDiagram)WebChartControl1.Diagram).AxisX.GridSpacingAuto = false;
		'((XYDiagram)WebChartControl1.Diagram).AxisX.GridSpacing = 1;

		WebChartControl1.DataBind()
	End Sub

	Protected Sub WebChartControl1_CustomCallback(ByVal sender As Object, ByVal e As DevExpress.XtraCharts.Web.CustomCallbackEventArgs)
		Dim parameters() As String = e.Parameter.Split(";"c)
		Dim originalArgument As DateTime = Convert.ToDateTime(hfOriginalArgument.Value, CultureInfo.InvariantCulture)
		Dim argument As DateTime = Convert.ToDateTime(parameters(0), CultureInfo.InvariantCulture)
		Dim value As Double = Convert.ToDouble(parameters(1))
		Dim table As DataTable = ManualDataSet.RetrieveDataCache().Tables(0)

		For i As Integer = 0 To table.Rows.Count - 1
			If Convert.ToDateTime(table.Rows(i)("MyDateTime")) = originalArgument Then
				table.Rows(i)("MyDateTime") = argument
				table.Rows(i)("MyData") = value
				Exit For
			End If
		Next i
	End Sub

End Class
Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Web

Public Class ManualDataSet
	Inherits DataSet
	Public Sub New()
		MyBase.New()
		Dim table As New DataTable("table")

		DataSetName = "ManualDataSet"

		table.Columns.Add("ID", GetType(Int32))
		table.Columns.Add("MyDateTime", GetType(DateTime))
		table.Columns.Add("MyRow", GetType(String))
		table.Columns.Add("MyData", GetType(Double))
		table.Constraints.Add("IDPK", table.Columns("ID"), True)

		Tables.AddRange(New DataTable() { table })
	End Sub

	Public Shared Function CreateData() As DataSet
		Dim ds As DataSet = New ManualDataSet()
		Dim table As DataTable = ds.Tables("table")

		table.Rows.Add(New Object() { 0, DateTime.Today.AddHours(1), "A", 103 })
		table.Rows.Add(New Object() { 1, DateTime.Today.AddHours(3), "B", 200 })
		table.Rows.Add(New Object() { 2, DateTime.Today.AddHours(6), "C", 446 })
		table.Rows.Add(New Object() { 3, DateTime.Today.AddHours(10), "D", 788 })
		table.Rows.Add(New Object() { 4, DateTime.Today.AddHours(15), "E", 674 })
		table.Rows.Add(New Object() { 5, DateTime.Today.AddHours(20), "F", 452 })

		Return ds
	End Function

	Public Shared Function RetrieveDataCache() As DataSet
		If HttpContext.Current.Session("dataset") Is Nothing Then
			HttpContext.Current.Session("dataset") = ManualDataSet.CreateData()
		End If

		Return CType(HttpContext.Current.Session("dataset"), DataSet)
	End Function

End Class


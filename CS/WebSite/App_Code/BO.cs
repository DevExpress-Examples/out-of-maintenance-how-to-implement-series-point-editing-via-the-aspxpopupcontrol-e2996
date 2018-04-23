using System;
using System.Data;
using System.Web;

public class ManualDataSet : DataSet {
    public ManualDataSet()
        : base() {
        DataTable table = new DataTable("table");

        DataSetName = "ManualDataSet";

        table.Columns.Add("ID", typeof(Int32));
        table.Columns.Add("MyDateTime", typeof(DateTime));
        table.Columns.Add("MyRow", typeof(string));
        table.Columns.Add("MyData", typeof(double));
        table.Constraints.Add("IDPK", table.Columns["ID"], true);

        Tables.AddRange(new DataTable[] { table });
    }

    public static DataSet CreateData() {
        DataSet ds = new ManualDataSet();
        DataTable table = ds.Tables["table"];

        table.Rows.Add(new object[] { 0, DateTime.Today.AddHours(1), "A", 103 });
        table.Rows.Add(new object[] { 1, DateTime.Today.AddHours(3), "B", 200 });
        table.Rows.Add(new object[] { 2, DateTime.Today.AddHours(6), "C", 446 });
        table.Rows.Add(new object[] { 3, DateTime.Today.AddHours(10), "D", 788 });
        table.Rows.Add(new object[] { 4, DateTime.Today.AddHours(15), "E", 674 });
        table.Rows.Add(new object[] { 5, DateTime.Today.AddHours(20), "F", 452 });

        return ds;
    }

    public static DataSet RetrieveDataCache() {
        if (HttpContext.Current.Session["dataset"] == null)
            HttpContext.Current.Session["dataset"] = ManualDataSet.CreateData();

        return (DataSet)HttpContext.Current.Session["dataset"];
    }

}
        

using Newtonsoft.Json;
using System.Data;
using System.Text;
using System.Xml;

namespace FkHelper;

public static class DataTableHelper
{
    /// <summary>
    /// CSV to Datatable
    /// </summary>
    /// <param name="strFilePath">檔案路徑</param>
    public static DataTable FromCsv(string strFilePath)
    {
        var dt = new DataTable();
        using var sr = new StreamReader(strFilePath, Encoding.Default);
        string[] headers = sr.ReadLine().Split(',');

        foreach (string header in headers)
        {
            dt.Columns.Add(header);
        }
        while (!sr.EndOfStream)
        {
            string[] rows = sr.ReadLine().Split(',');
            DataRow dr = dt.NewRow();
            for (int i = 0; i < headers.Length; i++)
            {
                dr[i] = rows[i];
            }
            dt.Rows.Add(dr);
        }

        return dt;
    }

    /// <summary>
    /// Json to Datatable
    /// </summary>
    /// <param name="jsonContent">format sample
    /// {
    /// "employees": [
    /// { "firstName":"John" , "lastName":"Doe" },
    /// { "firstName":"Anna" , "lastName":"Smith" },
    /// { "firstName":"Peter" , "lastName":"Jones" }]
    /// }
    ///
    /// </param>
    /// <returns></returns>
    public static DataTable FromJsonTo(string jsonContent)
    {
        var xml = JsonConvert.DeserializeXmlNode("{records:{record:" + jsonContent + "}}");
        var xmldoc = new XmlDocument();
        xmldoc.LoadXml(xml.InnerXml);

        var xmlReader = new XmlNodeReader(xml);
        var dataSet = new DataSet();
        dataSet.ReadXml(xmlReader);
        var dataTable = dataSet.Tables[1].Copy();
        dataTable.Columns.Remove("record_Id");
        return dataTable;
    }

}
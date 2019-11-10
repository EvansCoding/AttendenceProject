namespace BUS.Classes
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;

    public class ExcelDataBaseHelper
    {
        public static DataTable OpenFile(string fileName)
        {
            var fullFileName = fileName;
            if (!File.Exists(fullFileName))
            {
                System.Windows.Forms.MessageBox.Show("File not found");
                return null;
            }
            var connectionString = ProcessFile(fullFileName);
            var adapter = new OleDbDataAdapter("select * from [Sheet1$]", connectionString);
            var ds = new DataSet();
            string tableName = "excelData";
            adapter.Fill(ds, tableName);
            DataTable data = ds.Tables[tableName];
            return data;
        }

        private static string ProcessFile(string path)
        {
            string connString = string.Empty;

            if (Path.GetExtension(path).ToLower().Trim() == ".xls" && Environment.Is64BitOperatingSystem == false)
                return connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            else
                return connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
        }

    }
}

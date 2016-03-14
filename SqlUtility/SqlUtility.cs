using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Data;

namespace SqlUtility
{
    class SqlUtility
    {

        private string fileName;

        public SqlUtility(string fileName)
        {
            try
            {
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Directory.GetCurrentDirectory() + "/" + FileName;
                OleDbConnection conn = new OleDbConnection(connString);
                this.fileName = fileName;
            }
            catch (Exception e)
            {
                Console.WriteLine("The database was not found. Try again.");
            }
        }

        public string FileName
        {
            get { return this.fileName; }
            set { this.fileName = value; }
        }


        public static void ExceptionHandler(Exception e)
        {
            Console.WriteLine("Oh snap!, An error occurred");
            Console.WriteLine("Error: " + e.Message);
            Console.WriteLine("Please return to the start and try again");
        }

        public static OleDbConnection ConnectToDataBase()
        {
            try
            {
                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Directory.GetCurrentDirectory() + "/" + FileName;
                OleDbConnection conn = new OleDbConnection(connString);
                return conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecuteQuery(string query)
        {
            try
            {
                OleDbConnection connection = ConnectToDataBase();

                connection.Open();

                OleDbCommand command = new OleDbCommand(query, connection);

                command.ExecuteNonQuery();

                command.Dispose();

                connection.Close();
            }
            catch (Exception e)
            {
                ExceptionHandler(e);
            }
        }
        public static DataTable ExecuteDataTable(string query)
        {
            OleDbConnection conn = ConnectToDataBase();
            conn.Open();
            OleDbDataAdapter tableAdapter = new OleDbDataAdapter(query, conn);
            DataTable dt = new DataTable();
            tableAdapter.Fill(dt);
            return dt;
        }
        public static void PrintDataTable(DataTable dt)
        {
            string printStr = "<table border='1'>";

            foreach (DataRow row in dt.Rows)
            {
                printStr += "<tr>";
                foreach (object myItemArray in row.ItemArray)
                {

                    printStr += "<td>" + myItemArray.ToString() + "</td>";
                }
                printStr += "</tr>";
            }
            printStr += "</table>";

            return printStr;
        }
    }
    }
}

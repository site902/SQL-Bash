using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;


namespace SqlUtility
{
     class SqlUtility
    {

         private string fileName;

         public SqlUtility(string fileName)
         {
             this.fileName = fileName;
         }

         public string FileName
         {
             get {return this.fileName; }
             set {this.fileName = value; }
         }


         public static void ExceptionHandler(Exception e)
         {
             Console.WriteLine("Snap!, An error occurred");
             Console.WriteLine("the error is " + e.Message);
             Console.WriteLine("Please return to the start and try again");
         }

        public OleDbConnection ConnectToDataBase()
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
    }
}

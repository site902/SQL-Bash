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

        static bool SelectScanner(string query)
        {
            string s = "select";
            query = query.ToLower();

            string x = "";

            int i = 0;

            while (query[i].ToString() != "t")
            {
                if (query[i].ToString() == s[i].ToString())
                {
                    x += query[i].ToString();
                }
                i++;
            }

            if (x == s)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public static void ExceptionHandler(Exception e)
    {
        Console.WriteLine("Oh snap!, An error occurred");
        Console.WriteLine("Error: " + e.Message);
        Console.WriteLine("Please return to the start and try again");
    }

    public static OleDbConnection ConnectToDataBase(Query q)
    {
        try
        {
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Directory.GetCurrentDirectory() + "/" + q.FileName;
            Console.WriteLine(connString);
            OleDbConnection conn = new OleDbConnection(connString);
            return conn;
        }
        catch (Exception ex)
        {
            return null;
            throw ex;
        }
    }

    public static void ExecuteQuery(Query q)
    {
        try
        {
            if (ConnectToDataBase(q) != null)
            {
                OleDbConnection connection = ConnectToDataBase(q);
                connection.Open();
                OleDbCommand command = new OleDbCommand(q.Sql, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            else
            {
                throw new Exception("Connection to database failed. Check that the filename is correct and try again.");
            }
        }
        catch (Exception e)
        {
            ExceptionHandler(e);
        }
    }

    public static DataTable ExecuteDataTable(Query q)
    {
        OleDbConnection conn = ConnectToDataBase(q);
        conn.Open();

        OleDbDataAdapter tableAdapter = new OleDbDataAdapter(q.Sql, conn);

        DataTable dt = new DataTable();

        tableAdapter.Fill(dt);

        return dt;
    }

    public static string printDataTable(DataTable dt)
    {

        string printStr = "";

        foreach (DataRow row in dt.Rows)
        {
            foreach (object myItemArray in row.ItemArray)
            {

                printStr += myItemArray.ToString() + ", ";
            }

            printStr += "\n";
        }

        return printStr;
    }
}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine("Enter file name");

            string f = Console.ReadLine(), q , t;

            Query query;
            
            SqlUtility s = new SqlUtility(f);
            while (true)
            {

                Console.Write("Enter sql query: ");
                q = Console.ReadLine();

                Console.WriteLine("Enter TableName: ");
                t = Console.ReadLine();

                query = new Query(t, q);

                SqlUtility.ExecuteQuery(query);
            }
        }
    }
}

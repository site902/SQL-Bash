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
            Console.WriteLine("choose: ");
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.Start");

            string choise = Console.ReadLine();

            if (choise == "0")
            {
                Environment.Exit(-1);
            }
            else
            {
                Console.WriteLine(Directory.GetCurrentDirectory());
                inputFileName:
                Console.WriteLine("Enter file name");
                string f = Console.ReadLine();
                if (!File.Exists(Directory.GetCurrentDirectory() + f))
                {
                    Console.WriteLine("The file does not exist. Try again");
                    goto inputFileName;
                }
                Query query = new Query(f);

                while (true)
                {
                    Console.Write("Enter sql query: ");
                    query.Sql = Console.ReadLine();
                    SqlUtility.ExecuteQuery(query);
                }            
            }
        }
    }
}

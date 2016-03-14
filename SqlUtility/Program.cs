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
            Console.WriteLine("Enter file name");
            string f = Console.ReadLine(), q;

            while (true)
            {
                try
                {
                    Console.Write("Enter sql query: ");
                    q = Console.ReadLine();
                    MyAdoHelper.DoQuery(f, q);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
        }
    }
}

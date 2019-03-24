using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime x = new DateTime(2000, 1, 1);
            DateTime y = new DateTime(1998, 1, 1);
            TimeSpan z = x - y.AddYears(1);


            Console.WriteLine(z.Days);
            Console.ReadKey();

        }
    }
}

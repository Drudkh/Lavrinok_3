using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadacha_3
{
    class Program
    {
        static void Main(string[] args)

        {
            Random rand = new Random();
            DateTime BirthDate = new DateTime(rand.Next(1950, 2019), 1,1);
            int a = DateTime.Now.Year - BirthDate.Year;
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}

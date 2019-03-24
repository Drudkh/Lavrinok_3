using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavrinok
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonsGenerator generator = new PersonsGenerator();
            foreach (Person var in generator.Generate(5))
            {
                Console.WriteLine(var.GetpersonInfo()); 
            }
            Console.ReadKey();
        }
    }
}

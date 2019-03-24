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
            Console.WriteLine("-02-03------------------------------------------");
            Person[] persons = new PersonsGenerator().Generate(10);
            foreach (Person var in persons)
            {
                Console.WriteLine(var.GetpersonInfo()); 
            }

            Console.WriteLine("");
            Console.WriteLine("-04--------------------------------------------");

            Console.WriteLine("-04-01-------------------------------------------");
            new SalaryProcessor().Process(persons);
            Console.WriteLine("-04-02-------------------------------------------");
            new AgeStatisticProcessor().Process(persons);
            Console.WriteLine("-04-03-------------------------------------------");
            new NamesProcessor().Process(persons);

            Console.WriteLine("");
            Console.WriteLine("-05--------------------------------------------");
            foreach (Person var in persons)
            {
                Console.WriteLine(var.FullName + " => " + var.GetType().Name);
            }
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavrinok
{
    public class SalaryProcessor : PersonsProcessor
    {
        public override void Process(IEnumerable<Person> persons)
        {
            IEnumerator<Person> ie = persons.GetEnumerator();
            Person highlyPaidPerson = persons.First();

            while (ie.MoveNext())
            {
                if (ie.Current.Age >= 18)
                {
                    Console.WriteLine("{0}; Age: {1}; Overall earnings: {2}", ie.Current.FullName, ie.Current.Age, ie.Current.OverallEarnings);
                    if (highlyPaidPerson.OverallEarnings < ie.Current.OverallEarnings) highlyPaidPerson = ie.Current;
                }
            }
            Console.WriteLine("Info about highly payed person");
            Console.WriteLine("{0}; Age: {1}; Overall earnings: {2}", highlyPaidPerson.FullName, highlyPaidPerson.Age, highlyPaidPerson.OverallEarnings);
        }
    }
}

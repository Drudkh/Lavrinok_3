using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavrinok
{
    public class PersonsGenerator
    {
        public Person[] Generate(int amount)
        {
            string[] firstNames = { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian", "abby", "abigail", "adele", "adrian" };
            string[] lastNames = { "abbott", "acosta", "adams", "adkins", "aguilar" };
            Random rand = new Random();

            Person[] persons = new Person[amount];
            for (int i = 0; i < amount; i++)
            {
                Person person = new Person();
                person.FirstName = firstNames[rand.Next(0, firstNames.Length - 1)];
                person.LastName = lastNames[rand.Next(0, lastNames.Length - 1)];
                person.HourRate = (decimal)rand.Next(1, 100);
                person.BirthDate = new DateTime(rand.Next(1950, 2019), 1, 1);
                persons[i] = person;
            }
            return persons;
        }
    }
}

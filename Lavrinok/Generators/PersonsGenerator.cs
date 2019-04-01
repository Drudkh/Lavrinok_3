using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavrinok
{
    public class PersonsGenerator
    {
        private Person person;

        public Person[] Generate(int amount)
        {
            string[] firstNames = { "Tobias", "Morris", "Israel", "Randall", "Jerold", "Brandon", "Jerold", "Brandon", "Colin", "Booker", "Napoleon", "Addams" };
            string[] lastNames = { "Gragson", "Minier", "Philson", "Mayorga", "Cardone", "Brass", "Zwiell", "Sandovan", "Dickie" };
            Random rand = new Random();

            Person[] persons = new Person[amount];
            for (int i = 0; i < amount; i++)
            {
                Guid id = Guid.NewGuid();
                int j = rand.Next(0, 2);
                if (j == 0)
                { this.person = new Freelancer(); }
                else if (j == 1)
                { this.person = new Employee(); }
                else
                { this.person = new Subconractor(); }

                person.FirstName = firstNames[rand.Next(0, firstNames.Length - 1)];
                person.LastName = lastNames[rand.Next(0, lastNames.Length - 1)];
                person.HourRate = (decimal)rand.Next(1, 100);
                person.BirthDate = new DateTime(rand.Next(1950, 2019), 1, 1);
                person.PersonId = System.Guid.NewGuid().ToString();
                persons[i] = person;
            }

           return persons;
        }
    }
}

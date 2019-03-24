﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavrinok
{
    public class AgeStatisticProcessor : PersonsProcessor
    {
        public override void Process(IEnumerable<Person> persons)
        {
            IEnumerator<Person> ie = persons.GetEnumerator();
            int averageAge = 0;
            Person youngestPerson = persons.First();
            Person oldestPerson = persons.First();
            while (ie.MoveNext())
            {
                if (youngestPerson.BirthDate < ie.Current.BirthDate) youngestPerson = ie.Current;
                if (oldestPerson.BirthDate > ie.Current.BirthDate) oldestPerson = ie.Current;
                averageAge += ie.Current.Age;
            }
            Console.WriteLine("Average Age: {0}; Youngest Person: {1}; Oldest Person {2}", averageAge / persons.Count(), youngestPerson.FullName, oldestPerson.FullName);
        }
    }
}

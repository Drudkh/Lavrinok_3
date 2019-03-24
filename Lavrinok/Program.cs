using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavrinok
{
    class Person
    {
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal HourRate { get; set; }
        public int Age { 
            get { return DateTime.Now.Year - BirthDate.Year; }
        }
        public string FullName {
            get { return "FirstName:" + FirstName + " " + "LastName: " + LastName; }
        }

        public string GetpersonInfo()
        {
            string potSal;
            if (Age > 18)
            {
                potSal = (160 * (double)HourRate).ToString();
            }
            else
            {
                HourRate = 0m;
                potSal = "child";
            }
            return FullName + " Age: " + Age + " Potential Salary: " + potSal; 
        }

        public decimal OverallEarnings
        {
            get
            {
                int months = (DateTime.Today.Year * 12 + DateTime.Today.Month) - (BirthDate.AddYears(18).Year * 12 + BirthDate.AddYears(18).Month);
                return months * 160* HourRate;
            }
        }
    }

    class PersonsGenerator
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
                person.BirthDate = new DateTime (rand.Next(1950, 2019),1,1);
                persons[i] = person;
            }
             return persons;
        }
    }

    public abstract class PersonsProcessor
    {
        abstract public void Process(IEnumerable<Person> persons);
    }


    class SalaryProcessor : PersonsProcessor
    {
        public override void Process(IEnumerable<Person> persons)
        {
            IEnumerator<Person> ie = persons.GetEnumerator();
            Person highlyPaidPerson = persons.First();

            while (ie.MoveNext())
            {
                if (ie.Current.Age >= 18)
                {
                    Console.WriteLine("Full name: {0}; Age: {1}; Overall earnings: {2}", ie.Current.FullName, ie.Current.Age, ie.Current.OverallEarnings);
                    if (highlyPaidPerson.OverallEarnings < ie.Current.OverallEarnings) highlyPaidPerson = ie.Current;
                }
            }
            Console.WriteLine("Full name: {0}; Age: {1}; Overall earnings: {2}", highlyPaidPerson.FullName, highlyPaidPerson.Age, highlyPaidPerson.OverallEarnings);
        }
    }


    class AgeStatisticProcessor : PersonsProcessor
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
            Console.WriteLine("Average Age: {0}; Youngest Person: {1}; Oldest Person {2}", averageAge/persons.Count(), youngestPerson.FullName, oldestPerson.FullName);
        }
    }

    class NamesProcessor : PersonsProcessor
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        
        public override void Process(IEnumerable<Person> persons)
        {
            IEnumerator<Person> ie = persons.GetEnumerator();

            while (ie.MoveNext())
            {
                if (dict.ContainsKey(ie.Current.FirstName))
                    dict[ie.Current.FirstName] += 1;
                else
                    dict.Add(ie.Current.FirstName, 1);
            }
            foreach (KeyValuePair<string, int> keyValue in dict)
            {
                Console.WriteLine("FirstName:" + keyValue.Key + " is used " + 100*keyValue.Value/persons.Count() +"%");
            }
        }
    }




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

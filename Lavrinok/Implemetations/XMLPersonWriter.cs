using Lavrinok.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lavrinok.Implemetations
{
    class XMLPersonWriter : IPersonWriter
    {
        public void SerializeXml(List<Person> people)
        {
            FileStream fileStream = File.Open("persons.xml", FileMode.Open);
            fileStream.SetLength(0);
            fileStream.Close();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            using (FileStream file = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(file, people);
                Console.WriteLine("Serializable done");
            }
        }
        public List<Person> DeSerializeXml()
        {
            var deSerializable = new XmlSerializer(typeof(List<Person>));
            using (FileStream file = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                List<Person> newPeople = (List<Person>)deSerializable.Deserialize(file);
                return newPeople;
            }
        }

        public void Delete(string Id)
        {
            List<Person> peoples_from_xml = new List<Person>();
            peoples_from_xml = DeSerializeXml();

            foreach (var person in peoples_from_xml)
            {
                if (person.PersonId == Id)
                {
                    peoples_from_xml.Remove(person);
                    break;
                }
            }
            SerializeXml(peoples_from_xml);
        }

        public void Update(string Id)
        {
            List <Person> peoples_from_xml = new List<Person>();
            peoples_from_xml = DeSerializeXml();

            string[] firstNames = { "Tobias", "Morris", "Israel", "Randall", "Jerold", "Brandon", "Jerold", "Brandon", "Colin", "Booker", "Napoleon", "Addams" };
            string[] lastNames = { "Gragson", "Minier", "Philson", "Mayorga", "Cardone", "Brass", "Zwiell", "Sandovan", "Dickie" };
            Random rand = new Random();

            foreach (var person in peoples_from_xml)
            {
                if (person.PersonId == Id)
                {
                    person.FirstName = firstNames[rand.Next(0, firstNames.Length - 1)];
                    person.LastName = lastNames[rand.Next(0, lastNames.Length - 1)];
                    person.HourRate = (decimal)rand.Next(1, 100);
                    person.BirthDate = new DateTime(rand.Next(1950, 2019), 1, 1);
                }
                else
                {
                    Console.WriteLine("Ssory! We cann't find this guy in xmlfile"); 
                }
            }
            SerializeXml(peoples_from_xml);
        }
    }
}

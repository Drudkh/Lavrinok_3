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
    class XmlPersonReader : IPersonReader
    {
        public List<Person> DeSerializeXml()
        {
            var deSerializable = new XmlSerializer(typeof(List<Person>));
            using (FileStream file = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                List<Person> newPeople = (List<Person>)deSerializable.Deserialize(file);
                return newPeople;
            }
        }

        public List<Person> All()
        {
            return DeSerializeXml();
        }

        public Person ById(string Id)
        {
            List<Person> peoples_from_xml = new List<Person>();
            peoples_from_xml = DeSerializeXml();
            Person _person = new Person();

            foreach (var person in peoples_from_xml)
            {
                if (person.FirstName == Id)
                _person = person;
            }
            return _person;
        }
    }
}
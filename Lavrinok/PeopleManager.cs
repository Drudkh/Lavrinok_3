using Lavrinok.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavrinok
{
    class PeopleManager
    {
        IPersonReader _personReader;
        IPersonWriter _personWriter;
        PeopleManager(IPersonReader reader, IPersonWriter writer)
        {
            _personReader = reader;
            _personWriter = writer;
        }

        public void AddPeople(Person[] persons)
        {

        }
        public void AddPerson(Person person)
        {

        }

        public void UpdatePeople(string firstname)
        {

        }

        public void Delete(string firstname)
        {

        }

        public void BySalary(int min_age, int max_age)
        {
           var list = _personReader.All();

        }

        public void BySalary(double min_salary, double max_salary)
        {

        }

    }
}

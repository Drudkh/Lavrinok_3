using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavrinok.Interfaces
{
    interface IPersonReader
    {
        List<Person> All();
        Person ById(string name);
    }
}

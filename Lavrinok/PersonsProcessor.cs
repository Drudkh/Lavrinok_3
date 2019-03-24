using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavrinok
{
    public abstract class PersonsProcessor
    {
        abstract public void Process(IEnumerable<Person> persons);
    }
}

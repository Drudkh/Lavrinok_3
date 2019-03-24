using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavrinok
{
    public class NamesProcessor : PersonsProcessor
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
                Console.WriteLine("FirstName:" + keyValue.Key + " is used " + 100 * keyValue.Value / persons.Count() + "% times");
            }
        }
    }
}

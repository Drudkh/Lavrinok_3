using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavrinok.Interfaces
{
    interface IPersonWriter
    {
        void Update(string firstname);
        void Delete(string firstname);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavrinok
{
    class Subconractor : Person
    {
        public override decimal HourRate
        {
            get
            {
                return base.HourRate * (decimal)2.2;
            }
        }
    }
}

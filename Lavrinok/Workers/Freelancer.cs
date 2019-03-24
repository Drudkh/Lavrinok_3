using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavrinok
{
    class Freelancer : Person
    {
        public override decimal HourRate
        {
            get
            {
                return base.HourRate * (decimal)1.5;
            }
        }
    }
}

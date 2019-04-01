using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavrinok
{
    [Serializable]
    public class Person
    {
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual decimal HourRate { get; set; }
        public string PersonId { get; set;
}
        public Person()
        { }
        public int Age
        {
            get { return DateTime.Now.Year - BirthDate.Year; }
        }
        public string FullName
        {
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
                return months * 160 * HourRate;
            }
        }
    }
}

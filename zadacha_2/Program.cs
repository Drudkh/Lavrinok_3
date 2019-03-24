using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadacha_2
{
    public class RandomDateTime
    {
        public DateTime minDateTime { get; set; }
        public DateTime maxDateTime { get; set; }

        public DateTime RandomDATE(DateTime date_1, DateTime date_2)
        {
            if (date_1 < date_2)
            {
                minDateTime = date_1;
                maxDateTime = date_2;
            }
            else
            {
                minDateTime = date_2;
                maxDateTime = date_1;
            }
            System.TimeSpan diff1 = maxDateTime.Subtract(minDateTime);
            double delta = diff1.TotalDays;
            Random rnd = new Random();
            double new_delta = rnd.Next(0, (int)delta);
            System.TimeSpan diff2 = TimeSpan.FromDays(new_delta);
            DateTime my_date = minDateTime.Add(diff2);
            return my_date;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RandomDateTime obj = new RandomDateTime();
            DateTime my_datex = obj.RandomDATE(new DateTime(1999, 1, 1), new DateTime(2018, 10, 25));
            Console.WriteLine("год: {0} месяц: {1} день: {2}", my_datex.Year, my_datex.Month, my_datex.Day);
            Console.ReadKey();
        }
    }
}

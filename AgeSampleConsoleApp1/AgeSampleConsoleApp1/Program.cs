using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeSampleConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Age is {new DateTime(1987, 1, 5).ToAgeString()}");
            Console.WriteLine($"Age is {new DateTime(1991, 11, 22).ToAgeString()}");
            Console.WriteLine($"Age is {new DateTime(1995, 4, 12).ToAgeString()}");
            Console.WriteLine($"Age is {new DateTime(1973, 2, 15).ToAgeString()}");
            Console.WriteLine($"Age is {new DateTime(1982, 4, 12).ToAgeString()}");
            Console.WriteLine($"Age is {new DateTime(1982, 6, 11).ToAgeString()}");
            Console.WriteLine($"Age is {new DateTime(2018, 1, 1).ToAgeString()}");


            Console.ReadKey();
        }
    }

    public static class DateTimeExtensions
    {
        public static string ToAgeString(this DateTime dob)
        {
            DateTime today = DateTime.Today;

            int months = today.Month - dob.Month;
            int years = today.Year - dob.Year;

            if (today.Day < dob.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            int days = (today - dob.AddMonths((years * 12) + months)).Days;

            return string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
                                 years, (years == 1) ? "" : "s",
                                 months, (months == 1) ? "" : "s",
                                 days, (days == 1) ? "" : "s");
        }
    }

    public sealed class Age
    {
        public Age(DateTime dob)
        {
            ToAgeString(dob);
        }

        public int Year { get; private set; }

        public int Month { get; private set; }

        public int Day { get; private set; }

        void ToAgeString(DateTime dob)
        {
            DateTime today = DateTime.Today;

            int months = today.Month - dob.Month;
            int years = today.Year - dob.Year;

            if (today.Day < dob.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            this.Year = years;
            this.Month = months;

            int days = (today - dob.AddMonths((years * 12) + months)).Days;
            this.Day = days;
            //return string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
            //                     years, (years == 1) ? "" : "s",
            //                     months, (months == 1) ? "" : "s",
            //                     days, (days == 1) ? "" : "s");
        }

        /*
        public void AddMonth(int months)
        {
            this.Month += months;
            if (this.Month > 12)
            {
                this.Year += (int)this.Month / 12;
                this.Month = this.Month % 12;
            }
            if (this.Month == 0)
            {
                this.Month = 12;
                this.Year -= 1;
            }
        }
        */
    }
}

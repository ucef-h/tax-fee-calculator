using System;
using System.Linq;

namespace TaxCalculator.Domain
{
    public class TollCalendar
    {
        public CalendarConfig Configs { get; private set; }

        public TollCalendar(CalendarConfig configs)
        {
            Configs = configs;
        }

        public bool IsTollFreeDate(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            // if (year != 2013)
            // {
            //     return true;
            // }
            return Configs.DaysOfWeek.Contains((int)date.DayOfWeek)
                   || Configs.Months.Contains(month)
                   || Configs.Days.Any(holiday => holiday.Month == month && holiday.Day == day);
        }
    }
}
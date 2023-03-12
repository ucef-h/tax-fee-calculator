using System.Collections.Generic;

namespace TaxCalculator.Domain
{
    public class CalendarConfig
    {
        public CalendarConfig(
            IEnumerable<int> dayOfWeek,
            IEnumerable<int> months,
            IEnumerable<HolidayValues> days
        )
        {
            DaysOfWeek = dayOfWeek;
            Months = months;
            Days = days;
        }

        public IEnumerable<int> DaysOfWeek { get; private set; }

        public IEnumerable<int> Months { get; private set; }

        public IEnumerable<HolidayValues> Days { get; private set; }
    }

    public class HolidayValues
    {
        public int Day { get; private set; }

        public int Month { get; private set; }

        public HolidayValues(int day, int month)
        {
            Day = day;
            Month = month;
        }
    }
}
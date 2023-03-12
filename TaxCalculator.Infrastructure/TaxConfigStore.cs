using System;
using System.Threading.Tasks;
using TaxCalculator.Domain;

namespace TaxCalculator.Infrastructure
{
    public class TaxConfigStore : ITaxConfigStore
    {
        public async Task<TaxConfig> GetConfigByCity(string city)
        {
            await Task.CompletedTask;

            if (city == "Gothenburg")
            {
                return GothenburgConfig();
            }

            return null;
        }


        private static TaxConfig GothenburgConfig()
        {
            return new TaxConfig()
            {
                CalendarConfig = new CalendarConfig(
                    new[] { (int)DayOfWeek.Saturday, (int)DayOfWeek.Sunday, },
                    new[] { 7 },
                    new[]
                    {
                        new HolidayValues(day: 1, month: 1),
                        new HolidayValues(day: 28, month: 3),
                        new HolidayValues(day: 29, month: 3),
                        new HolidayValues(day: 1, month: 4),
                        new HolidayValues(day: 30, month: 5),
                        new HolidayValues(day: 5, month: 6),
                        new HolidayValues(day: 6, month: 6),
                        new HolidayValues(day: 21, month: 6),
                        new HolidayValues(day: 1, month: 11),
                        new HolidayValues(day: 24, month: 12),
                        new HolidayValues(day: 25, month: 12),
                        new HolidayValues(day: 26, month: 12),
                        new HolidayValues(day: 31, month: 12),
                    }
                ),
                FeeConfigs = new[]
                {
                    new FeeConfig(new TimeValue(6, 0), new TimeValue(6, 29), 8),
                    new FeeConfig(new TimeValue(6, 30), new TimeValue(6, 59), 13),
                    new FeeConfig(new TimeValue(7, 0), new TimeValue(7, 59), 18),
                    new FeeConfig(new TimeValue(8, 0), new TimeValue(8, 29), 13),
                    new FeeConfig(new TimeValue(8, 30), new TimeValue(14, 59), 8),
                    new FeeConfig(new TimeValue(15, 0), new TimeValue(15, 29), 13),
                    new FeeConfig(new TimeValue(15, 30), new TimeValue(16, 59), 18),
                    new FeeConfig(new TimeValue(17, 0), new TimeValue(17, 59), 13),
                    new FeeConfig(new TimeValue(18, 0), new TimeValue(18, 29), 8),
                },
                TollFreeVehicles = new[] { "Motorcycle", "Tractor", "Emergency", "Diplomat", "Foreign", "Military", }
            };
        }
    }
}

// this be the bug? if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18;

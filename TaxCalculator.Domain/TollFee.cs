using System;
using System.Collections.Generic;
using System.Linq;

namespace TaxCalculator.Domain
{
    public class TollFee
    {
        public IEnumerable<FeeConfig> Configs { get; private set; }

        public TollFee(IEnumerable<FeeConfig> configs)
        {
            Configs = configs;
        }


        public int GetFee(DateTime date)
        {
            var feeConfig = Configs.FirstOrDefault(fee =>
            {
                var date1 = new DateTime(date.Year, date.Month, date.Day, fee.Start.Hour, fee.Start.Minute, 0);
                var date2 = new DateTime(date.Year, date.Month, date.Day, fee.End.Hour, fee.End.Minute, 0);
                return date1 <= date && date >= date2;
            });

            return feeConfig?.Fee ?? 0;
        }
    }
}
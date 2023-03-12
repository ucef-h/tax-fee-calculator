using System.Collections.Generic;

namespace TaxCalculator.Domain
{
    public class CityTaxConfig
    {
        public string City { get; set; }
        public TaxConfig Config { get; set; }
    }

    public class TaxConfig
    {
        public CalendarConfig CalendarConfig { get; set; }
        public IEnumerable<string> TollFreeVehicles { get; set; }
        public IEnumerable<FeeConfig> FeeConfigs { get; set; }
    }
}
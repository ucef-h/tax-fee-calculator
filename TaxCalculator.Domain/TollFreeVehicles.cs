using System.Collections.Generic;
using System.Linq;
using TaxCalculator.Domain.Vehicles;

namespace TaxCalculator.Domain
{
    public class TollFreeVehicles
    {
        private IEnumerable<string> Types { get; set; }

        public TollFreeVehicles(IEnumerable<string> vehicleTypes)
        {
            Types = vehicleTypes;
        }

        public bool IsTollFree(Vehicle vehicle)
        {
            return Types.Contains(vehicle.GetVehicleType());
        }
    }
}
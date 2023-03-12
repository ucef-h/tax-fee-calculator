using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculator.Domain;
using TaxCalculator.Domain.Vehicles;

namespace TaxCalculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxCalculatorController : ControllerBase
    {
        private readonly ITaxConfigStore _store;

        public TaxCalculatorController(ITaxConfigStore store)
        {
            _store = store;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateTax(VehicleTaxRequest request)
        {
            var config = await _store.GetConfigByCity(request.City);
            var calculator = new CongestionTaxCalculator(config);
            var vehicle = CreateVehicleBasedOnName(request.Vehicle);
            return Ok(calculator.GetTax(vehicle, request.Dates));
        }

        // just a quick way to specify the vehicle by api, should be with DTOs
        private Vehicle CreateVehicleBasedOnName(string requestVehicle)
        {
            // // .
            var v = (from asm in new[] { typeof(Vehicle).Assembly }
                     from type in asm.GetTypes()
                     where type.IsClass && type.Name == requestVehicle
                     select type).Single();
            return Activator.CreateInstance(v) as Vehicle ?? throw new Exception("Vehicle type not found");
        }
    }

    public class VehicleTaxRequest
    {
        public string City { get; set; }
        public string Vehicle { get; set; }
        public DateTime[] Dates { get; set; }
    }
}
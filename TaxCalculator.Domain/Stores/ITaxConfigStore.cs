using System.Threading.Tasks;

namespace TaxCalculator.Domain
{
    public interface ITaxConfigStore
    {
        public Task<TaxConfig> GetConfigByCity(string city);
    }
}
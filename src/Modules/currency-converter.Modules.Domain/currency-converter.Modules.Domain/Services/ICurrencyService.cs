using System.Collections.Generic;
using System.Threading.Tasks;

namespace currency_converter.Modules.Domain.Services
{
    public interface ICurrencyService
    {
        public Task<Dictionary<string, string>> GetAvailableCurrencies();
    }
}

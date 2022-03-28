using currency_converter.Modules.Domain.Services;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace currency_converter.Adapters.Provider
{
    public class CurrencyService : ICurrencyService
    {
        public CurrencyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        public async Task<Dictionary<string, string>> GetAvailableCurrencies()
        {
            var client = new RestClient(_configuration.GetSection("Services:BaseUrl").Value);
            var request = new RestRequest(_configuration.GetSection("Services:CurrencyUrl").Value, Method.Get);
            return await client.GetAsync<Dictionary<string, string>>(request);
        }
    }
}

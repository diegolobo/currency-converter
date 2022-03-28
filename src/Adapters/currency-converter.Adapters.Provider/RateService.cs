using AutoMapper;
using currency_converter.Adapters.Provider.DTO;
using currency_converter.Modules.Domain.Entities;
using currency_converter.Modules.Domain.Services;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace currency_converter.Adapters.Provider
{
    public class RateService : IRateService
    {
        public RateService(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public async Task<Rate> GetRate(string from, string to)
        {
            try
            {
                var client = new RestClient(_configuration.GetSection("Services:BaseUrl").Value);
                client.UseNewtonsoftJson();
                var request = new RestRequest($"/{from}-{to}/1", Method.Get);
                request.RequestFormat = DataFormat.Json;
                var result = await client.GetAsync<RateDto[]>(request);
                return _mapper.Map<Rate>(result.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return new Rate { Code = "CoinNotExists" };
            }
        }
    }
}

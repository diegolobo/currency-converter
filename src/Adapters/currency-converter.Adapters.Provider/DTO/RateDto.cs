using Newtonsoft.Json;

namespace currency_converter.Adapters.Provider.DTO
{
    public class RateDto
    {
        [JsonProperty("codein")]
        public string Code { get; set; }

        [JsonProperty("low")]
        public string Value { get; set; }
    }
}

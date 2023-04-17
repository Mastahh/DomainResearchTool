using Newtonsoft.Json;

namespace DomainResearchTool.Models.DataForSeo
{
    public class DomainWhoisOverviewRequest
    {
        [JsonProperty("limit")]
        public int Limit { get; set; } = 100;

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("filters")]
        public List<object> Filters { get; set; } = new List<object>();
    }
}

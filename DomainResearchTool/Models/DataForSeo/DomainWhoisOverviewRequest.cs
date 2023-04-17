using System.Text.Json.Serialization;

namespace DomainResearchTool.Models.DataForSeo
{
    public class DomainWhoisOverviewRequest
    {
        [JsonPropertyName("limit")]
        public int Limit { get; set; } = 100;

        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("filters")]
        public List<object> Filters { get; set; } = new List<object>();
    }
}

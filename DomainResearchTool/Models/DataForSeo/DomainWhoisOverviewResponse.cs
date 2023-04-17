using System.Text.Json.Serialization;

namespace DomainResearchTool.Models.DataForSeo
{
    public class DomainWhoisOverviewResponse
    {
        [JsonPropertyName("version")]
        public string Version { get; set; } = string.Empty;

        [JsonPropertyName("status_code")]
        public int StatisCode { get; set; }

        [JsonPropertyName("status_message")]
        public string StatisMessage { get; set; } = string.Empty;

        [JsonPropertyName("tasks")]
        public List<object> Tasks { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace DomainResearchTool.Models.DataForSeo
{
    public class TaskResultItemResponse
    {
        [JsonPropertyName("domain")]
        public string Domain { get; set; } = string.Empty;

        [JsonPropertyName("created_datetime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonPropertyName("changed_datetime")]
        public DateTime ChangedDateTime { get; set; }

        [JsonPropertyName("expiration_datetime")]
        public DateTime ExpirationDateTime { get; set; }

        [JsonPropertyName("updated_datetime")]
        public DateTime UpdatedDateTime { get; set; }

        [JsonPropertyName("first_seen")]
        public DateTime FirstSeen { get; set; }
    }
}
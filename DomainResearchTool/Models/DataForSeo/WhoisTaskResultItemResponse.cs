using Newtonsoft.Json;

namespace DomainResearchTool.Models.DataForSeo
{
    public class WhoisTaskResultItemResponse : BaseTaskResultItemResponse
    {
        [JsonProperty("domain")]
        public string Domain { get; set; } = string.Empty;

        [JsonProperty("created_datetime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty("changed_datetime")]
        public DateTime ChangedDateTime { get; set; }

        [JsonProperty("expiration_datetime")]
        public DateTime ExpirationDateTime { get; set; }

        [JsonProperty("updated_datetime")]
        public DateTime UpdatedDateTime { get; set; }

        [JsonProperty("first_seen")]
        public DateTime FirstSeen { get; set; }

        [JsonProperty("metrics")]
        public Metrics Metrics { get; set; }

        [JsonProperty("backlinks_info")]
        public TaskBacklinksInfo BacklinksInfo { get; set; }
    }
}
using Newtonsoft.Json;

namespace DomainResearchTool.Models.DataForSeo
{
    public class SERPRequest
    {
        [JsonProperty("language_code")]
        public string LanguageCode { get; set; } = string.Empty;

        [JsonProperty("device")]
        public string Device { get; set; } = string.Empty;

        [JsonProperty("os")]
        public string Os { get; set; } = string.Empty;

        [JsonProperty("location_code")]
        public int LocationCode { get; set; }

        [JsonProperty("block_depth")]
        public int BlockDepth { get; set; }

        [JsonProperty("keyword")]
        public string Keyword { get; set; } = string.Empty;
    }
}

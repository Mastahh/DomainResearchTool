using Newtonsoft.Json;

namespace DomainResearchTool.Models.DataForSeo
{
    public class TaskBacklinksInfo
    {
        [JsonProperty("referring_domains")]
        public int ReferringDomains { get; set; }

        [JsonProperty("referring_main_domains")]
        public int ReferringMainDomains { get; set; }

        [JsonProperty("referring_pages")]
        public int ReferringPages { get; set; }

        [JsonProperty("dofollow")]
        public int Dofollow { get; set; }

        [JsonProperty("backlinks")]
        public int Backlinks { get; set; }

        [JsonProperty("time_update")]
        public DateTime TimeUpdate { get; set; }
    }
}

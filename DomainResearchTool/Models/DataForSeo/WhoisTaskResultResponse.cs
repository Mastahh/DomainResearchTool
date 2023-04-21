using Newtonsoft.Json;

namespace DomainResearchTool.Models.DataForSeo
{
    public class WhoisTaskResultResponse : BaseTaskResultResponse<WhoisTaskResultItemResponse>
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
    }
}

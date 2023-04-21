using Newtonsoft.Json;

namespace DomainResearchTool.Models.DataForSeo
{
    public class SERPTaskResultResponse : BaseTaskResultResponse<BaseTaskResultItemResponse>
    {
        [JsonProperty("se_results_count")]
        public int SeResultsCount { get; set; }
    }
}

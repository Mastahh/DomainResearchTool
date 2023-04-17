using Newtonsoft.Json;

namespace DomainResearchTool.Models.DataForSeo
{
    public class TaskResultResponse
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("items_count")]
        public int ItemsCount { get; set; }

        [JsonProperty("items")]
        public List<TaskResultItemResponse> Items { get; set; } = new List<TaskResultItemResponse>();

    }
}
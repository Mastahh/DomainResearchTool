using System.Text.Json.Serialization;

namespace DomainResearchTool.Models.DataForSeo
{
    public class TaskResultResponse
    {
        [JsonPropertyName("total_count")]
        public int TotalCount { get; set; }

        [JsonPropertyName("items_count")]
        public int ItemsCount { get; set; }

        [JsonPropertyName("items")]
        public List<TaskResultItemResponse> Items { get; set; } = new List<TaskResultItemResponse>();

    }
}
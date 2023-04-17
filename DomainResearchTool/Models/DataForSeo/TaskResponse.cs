using System.Text.Json.Serialization;

namespace DomainResearchTool.Models.DataForSeo
{
    public class TaskResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }

        [JsonPropertyName("status_message")]
        public string StatusMessage { get; set; } = string.Empty;

        [JsonPropertyName("result")]
        public List<TaskResultResponse> Result { get; set; } = new List<TaskResultResponse>();
    }
}

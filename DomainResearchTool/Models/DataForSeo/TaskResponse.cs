using Newtonsoft.Json;

namespace DomainResearchTool.Models.DataForSeo
{
    public class TaskResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("status_message")]
        public string StatusMessage { get; set; } = string.Empty;

        [JsonProperty("result")]
        public List<TaskResultResponse> Result { get; set; } = new List<TaskResultResponse>();
    }
}

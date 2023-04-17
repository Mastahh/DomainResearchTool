using System.Text.Json.Serialization;

namespace DomainResearchTool.Models.DataForSeo
{
    public class DomainWhoisOverviewResponse
    {
        [JsonPropertyName("version")]
        public string Version { get; set; } = string.Empty;

        [JsonPropertyName("status_code")]
        public int StatisCode { get; set; }

        [JsonPropertyName("status_message")]
        public string StatisMessage { get; set; } = string.Empty;

        [JsonPropertyName("tasks")]
        public List<TaskResponse> Tasks { get; set; }

        public bool IsError()
        {
            var task = Tasks.FirstOrDefault();
            if (task != null && task.StatusCode >= 40000)
            {
                return true;
            }
            return false;
        }

        public string GetErrorMessage()
        {
            var task = Tasks.FirstOrDefault();
            if (task != null && task.StatusCode >= 40000)
            {
                return task.StatusMessage;
            }
            return string.Empty;
        }
    }
}

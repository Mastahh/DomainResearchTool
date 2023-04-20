using Newtonsoft.Json;

namespace DomainResearchTool.Models.DataForSeo
{
    public class BaseResponse
    {
        [JsonProperty("version")]
        public string Version { get; set; } = string.Empty;

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("status_message")]
        public string StatusMessage { get; set; } = string.Empty;

        [JsonProperty("tasks")]
        public List<TaskResponse> Tasks { get; set; }

        public bool IsError()
        {
            if (StatusCode >= 40000)
            {
                return true;
            }
            if (Tasks != null)
            {
                var task = Tasks.FirstOrDefault();
                if (task != null && task.StatusCode >= 40000)
                {
                    return true;
                }
            }
            return false;
        }

        public virtual string GetErrorMessage()
        {
            if (!string.IsNullOrWhiteSpace(StatusMessage))
            {
                return StatusMessage;
            }
            if (Tasks != null)
            {
                var task = Tasks.FirstOrDefault();
                if (task != null && task.StatusCode >= 40000)
                {
                    return task.StatusMessage;
                }
            }
            return string.Empty;
        }
    }
}

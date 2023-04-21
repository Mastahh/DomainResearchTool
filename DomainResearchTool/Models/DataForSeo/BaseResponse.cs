using Newtonsoft.Json;

namespace DomainResearchTool.Models.DataForSeo
{
    public interface IBaseResponse
    {
        bool IsError();
        string GetErrorMessage();
        bool HasAnyTasks();
        bool HasAnyResultInTask();
    }

    public class BaseResponse<TTaskResponse, TTaskResultResponse, TItemResponseModel> : IBaseResponse
        where TTaskResponse: BaseTaskResponse<TTaskResultResponse, TItemResponseModel>
        where TTaskResultResponse: BaseTaskResultResponse<TItemResponseModel>
        where TItemResponseModel : BaseTaskResultItemResponse
    {
        protected const int _api_internal_error = 40000;

        [JsonProperty("version")]
        public string Version { get; set; } = string.Empty;

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("status_message")]
        public string StatusMessage { get; set; } = string.Empty;

        [JsonProperty("tasks")]
        public List<TTaskResponse> Tasks { get; set; }

        public bool IsError()
        {
            if (StatusCode >= _api_internal_error)
            {
                return true;
            }
            if (Tasks != null)
            {
                var task = Tasks.FirstOrDefault();
                if (task != null && task.StatusCode >= _api_internal_error)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetErrorMessage()
        {
            if (StatusCode >= _api_internal_error && !string.IsNullOrWhiteSpace(StatusMessage))
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

        public bool HasAnyTasks()
        {
            return Tasks.FirstOrDefault() != null;
        }

        public bool HasAnyResultInTask()
        {
            if (HasAnyTasks())
            {
                return Tasks.FirstOrDefault().Result.FirstOrDefault() != null;
            }
            return false;
        }
    }
}

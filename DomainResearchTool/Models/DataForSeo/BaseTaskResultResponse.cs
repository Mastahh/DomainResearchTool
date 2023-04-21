using Newtonsoft.Json;

namespace DomainResearchTool.Models.DataForSeo
{
    public class BaseTaskResultResponse<TItemResponseModel>
        where TItemResponseModel : BaseTaskResultItemResponse
    {
        [JsonProperty("items_count")]
        public int ItemsCount { get; set; }

        [JsonProperty("items")]
        public List<TItemResponseModel> Items { get; set; } = new List<TItemResponseModel>();
    }
}
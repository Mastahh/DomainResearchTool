using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace DomainResearchTool.Models.DataForSeo
{
    public class DomainWhoisOverviewRequest
    {
        private List<object> _filters = new List<object>();

        [JsonProperty("limit")]
        public int Limit { get; private set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("filters")]
        public ReadOnlyCollection<object> Filters { get { return _filters.AsReadOnly(); } }

        public void SetFilters(List<object> filters)
        {
            Limit = filters.Count();
            _filters = filters;
        }
    }
}

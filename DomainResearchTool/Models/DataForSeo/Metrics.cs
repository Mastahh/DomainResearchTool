using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DomainResearchTool.Models.DataForSeo
{
    public class Metrics
    {
        [JsonProperty("organic")]
        public Metric Organic { get; set; }

        [JsonProperty("paid")]
        public Metric Paid { get; set; }
    }
}

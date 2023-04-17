using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DomainResearchTool.Models.DataForSeo
{
    public class Metric
    {
        [JsonProperty("pos_1")]
        public int Pos_1 { get; set; }

        [JsonProperty("pos_2_3")]
        public int Pos_2_3 { get; set; }

        [JsonProperty("pos_4_10")]
        public int Pos_4_10 { get; set; }

        [JsonProperty("pos_11_20")]
        public int Pos_11_20 { get; set; }

        [JsonProperty("pos_21_30")]
        public int Pos_21_30 { get; set; }

        [JsonProperty("pos_31_40")]
        public int Pos_31_40 { get; set; }

        [JsonProperty("pos_41_50")]
        public int Pos_41_50 { get; set; }

        [JsonProperty("pos_51_60")]
        public int Pos_51_60 { get; set; }

        [JsonProperty("pos_61_70")]
        public int Pos_61_70 { get; set; }

        [JsonProperty("pos_71_80")]
        public int Pos_71_80 { get; set; }

        [JsonProperty("pos_81_90")]
        public int Pos_81_90 { get; set; }

        [JsonProperty("pos_91_100")]
        public int Pos_91_100 { get; set; }

        [JsonProperty("etv")]
        public float Etv { get; set; }

        [JsonProperty("impressions_etv")]
        public float ImpressionsEtv { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("estimated_paid_traffic_cost")]
        public float EstimatedPaidTrafficCost { get; set; }
    }
}

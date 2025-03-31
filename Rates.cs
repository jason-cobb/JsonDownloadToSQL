using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DataToSQLiteAI
{
    public class Rates
    {
       public Refrate[] refRates { get; set; }
    }
    public class Refrate
    {
        [JsonPropertyName("effectiveDate")]
        public string EffectiveDate { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("average30day")]
        public decimal Average30day { get; set; }
        [JsonPropertyName("average90day")]
        public decimal Average90day { get; set; }
        [JsonPropertyName("average180day")]
        public decimal Average180day { get; set; }
        [JsonPropertyName("index")]
        public decimal Index { get; set; }
        [JsonPropertyName("revisionIndicator")]
        public string RevisionIndicator { get; set; }
        [JsonPropertyName("percentRate")]
        public decimal PercentRate  { get; set; }

    }
}

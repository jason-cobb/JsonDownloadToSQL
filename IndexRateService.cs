using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataToSQLiteAI
{
    public class IndexRateService
    {
        public static async Task<List<IndexRate>> GetIndexRates(string json)
        {
            Rates jsonObject = JsonSerializer.Deserialize<Rates>(json);
            var sortedRates = jsonObject.refRates.OrderBy(r => r.Type).ToList();

            List<IndexRate> indexRates = new List<IndexRate>();
            DateTime today = DateTime.Now;
            string effectiveDate = string.Empty;
            bool hasTodaysEffectiveDate = false;
            foreach (var item in sortedRates)
            {
                var todayString = today.ToString("yyyy-MM-dd");
                bool isEffectiveDate = false;
                if (item.EffectiveDate == todayString)
                {
                    isEffectiveDate = true;
                }
                if (item.Type == "SOFRAI" && isEffectiveDate)
                {
                    hasTodaysEffectiveDate = true;
                    effectiveDate = item.EffectiveDate;

                    IndexRate r40 = new IndexRate();
                    r40.EffectiveDate = effectiveDate;
                    r40.IndexNo = "R40";
                    r40.Rate = item.Average30day / 100;
                    indexRates.Add(r40);

                    IndexRate r41 = new IndexRate();
                    r41.EffectiveDate = effectiveDate;
                    r41.IndexNo = "R41";
                    r41.Rate = item.Average90day / 100;
                    indexRates.Add(r41);

                    IndexRate r42 = new IndexRate();
                    r42.EffectiveDate = effectiveDate;
                    r42.IndexNo = "R42";
                    r42.Rate = item.Average180day / 100;
                    indexRates.Add(r42);
                }
                if (hasTodaysEffectiveDate)
                {
                    foreach (var itemtwo in sortedRates)
                    {
                        if (itemtwo.Type == "SOFR")
                        {
                            IndexRate r38 = new IndexRate();
                            r38.EffectiveDate = effectiveDate;
                            r38.IndexNo = "R38";
                            r38.Rate = itemtwo.PercentRate / 100;
                            indexRates.Add(r38);
                            break;
                        }
                    }
                }
            }
            return indexRates;
        }
        
    }
}

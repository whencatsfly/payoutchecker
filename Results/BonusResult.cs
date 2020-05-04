using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLinesTest.Results
{
    public class BonusDetails
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string BonusId { get; set; }

        [JsonProperty(PropertyName = "winPositions")]
        public WinPosition[] WinPositions { get; set; }
    }

    public class BonusResult
    {
        [JsonProperty(PropertyName = "isCompleted")]
        public bool BonusCompleted { get; set; }
        [JsonProperty(PropertyName = "win")]
        public string TotalWin { get; set; }
        [JsonProperty(PropertyName = "bet")]
        public string TotalBet { get; set; }
        [JsonProperty(PropertyName = "uniqueID")]
        public string TxnId { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "spinResult")]
        public BonusDetails BonusNum { get; set; }

    }

    public class WinPosition
    {
        [JsonProperty(PropertyName = "count")]
        public string Count { get; set; }
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }
        [JsonProperty(PropertyName = "win")]
        public string Win { get; set; }
        [JsonProperty(PropertyName = "multiplier")]
        public string Multiplier { get; set; }
        [JsonProperty(PropertyName = "wildMultiplier")]
        public string WildMultiplier { get; set; }
    }

}

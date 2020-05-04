using Newtonsoft.Json;

namespace WinLinesTest.Results
{
    public class Bonus
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string BonusId { get; set; }
    }

    public class SpinResult
    {
        [JsonProperty(PropertyName = "bet")]
        public string TotalBet { get; set; }
        [JsonProperty(PropertyName = "win")]
        public string TotalWin { get; set; }
        [JsonProperty(PropertyName = "uniqueID")]
        public string TxnId { get; set; }
        [JsonProperty(PropertyName = "hasBonus")]
        public bool hasBonus { get; set; }
        [JsonProperty(PropertyName = "bonus")]
        public Bonus Bonus { get; set; }
        [JsonProperty(PropertyName = "winPositions")]
        public WinPositions[] WinPosition  { get; set; }


    }

    public class WinPositions
    {
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
        [JsonProperty(PropertyName = "symbol")]
        public int Symbol { get; set; }
        [JsonProperty(PropertyName = "win")]
        public decimal Win { get; set; }
        [JsonProperty(PropertyName = "multiplier")]
        public double Multiplier { get; set; }
        [JsonProperty(PropertyName = "wildMultiplier")]
        public int WildMultiplier { get; set; }
    }
}

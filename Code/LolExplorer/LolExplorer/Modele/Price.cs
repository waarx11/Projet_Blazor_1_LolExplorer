using System.Text.Json.Serialization;

namespace LolExplorer.Modele
{
    public class Price
    {
        [JsonPropertyName("base")]
        public int Base { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("sell")]
        public int Sell { get; set; }
        public Price() { }
        public Price(int Base, int Total, int Sell)
        {
            this.Base = Base;
            this.Total = Total;
            this.Sell = Sell;
        }
    }
}

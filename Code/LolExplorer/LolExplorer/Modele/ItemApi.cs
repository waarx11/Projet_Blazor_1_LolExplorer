using System.Text.Json.Serialization;

namespace LolExplorer.Modele
{
    public class ItemApi
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("plaintext")]
        public string Plaintext { get; set; }
        [JsonPropertyName("into")]
        public List<string> Into { get; set; }
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("price")]
        public Price Price { get; set; }
        [JsonPropertyName("purchasable")]
        public bool Purchasable { get; set; }
        [JsonPropertyName("from")]
        public List<int> From { get; set; }

    }
}

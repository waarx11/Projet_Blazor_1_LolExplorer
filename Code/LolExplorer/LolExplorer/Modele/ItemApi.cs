namespace LolExplorer.Modele
{
    public class ItemApi
    {
        
        public string name { get; set; }
        public string plaintext { get; set; }
        public List<string> into { get; set; }
        public List<string> tags { get; set; }
        public string id { get; set; }
        public string icon { get; set; }
        public Price price { get; set; }
        public bool purchasable { get; set; } 
        public List<string> from { get; set; }

    }
}

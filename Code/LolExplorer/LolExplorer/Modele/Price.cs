namespace LolExplorer.Modele
{
    public class Price
    {
        public int Base { get; set; }
        public int Total { get; set; }
        public int Sell { get; set; }

        public Price(int Base, int Total, int Sell)
        {
            Base = Base;
            Total = Total;
            Sell = Sell;
        }
    }
}

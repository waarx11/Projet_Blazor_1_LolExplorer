namespace LolExplorer.Shared
{
    public class PositionOptions
    {
  
        public const string Position = "Position";

        public string Title { get; set; }
        public List<string> Name { get; set; }=new List<string>();
        public string Group { get; set; }
        public string Year { get; set; }
        public string Institution { get; set; }

    }
}

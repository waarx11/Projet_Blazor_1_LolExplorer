using LolExplorer.Modele;
namespace LolExplorer.Components
{
    public class CraftingRecipe
    {
        public ItemApi Give { get; set; }
        public List<string> Have { get; set; } = new();
    }
}
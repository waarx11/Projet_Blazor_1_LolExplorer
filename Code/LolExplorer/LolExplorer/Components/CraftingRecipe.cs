using LolExplorer.Modele;
namespace LolExplorer.Components
{
    public class CraftingRecipe
    {
        public ItemApi Give { get; set; }
        public List<List<string>> Have { get; set; }
    }
}
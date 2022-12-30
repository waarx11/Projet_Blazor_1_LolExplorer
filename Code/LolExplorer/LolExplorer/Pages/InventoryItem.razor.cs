using LolExplorer.Components;
using LolExplorer.Modele;
using LolExplorer.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace LolExplorer.Pages
{
    public partial class InventoryItem : Crafting 
    {
        //private const int inventorySize = 33;


        [Inject]
        public IStringLocalizer<InventoryItem> Localizer { get; set; }

        public List<ItemApi> Items { get; set; } = new List<ItemApi>();
        [Inject]
        public IDataService DataService { get; set; }
        private List<CraftingRecipe> Recipes { get; set; } = new List<CraftingRecipe>();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            base.OnAfterRenderAsync(firstRender);

            if (!firstRender)
            {
                return;
            }
            base.RecipeItems = await DataService.AllInventory();
            Items = await DataService.List(0, await DataService.Count());
            Recipes = await DataService.GetRecipes();
            StateHasChanged();
        }


        public async override void CheckRecipe()
        {
            await DataService.AddInventory(base.RecipeItems);
            StateHasChanged();
        }


    }
}

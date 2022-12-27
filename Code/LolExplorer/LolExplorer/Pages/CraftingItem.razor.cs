using LolExplorer.Components;
using LolExplorer.Modele;
using LolExplorer.Services;
using Microsoft.AspNetCore.Components;

namespace LolExplorer.Pages
{
    public partial class CraftingItem
    {
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

            Items = await DataService.List(0, await DataService.Count());
            Recipes = new List<CraftingRecipe>
            {
                new CraftingRecipe
                {
                    Give = new ItemApi { Name = "Diamond" },
                    Have = new List<List<string>>
                    {
                        new List<string> { "dirt", "dirt", "dirt" },
                        new List<string> { "dirt", null, "dirt" },
                        new List<string> { "dirt", "dirt", "dirt" }
                    }
                }

            };
            


            StateHasChanged();
        }
    }
}

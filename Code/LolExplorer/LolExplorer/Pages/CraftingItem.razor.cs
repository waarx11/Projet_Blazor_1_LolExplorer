﻿using LolExplorer.Components;
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

            Items = await DataService.AllInventory();
            Recipes = await DataService.GetRecipes();
            StateHasChanged();
        }
    }
}

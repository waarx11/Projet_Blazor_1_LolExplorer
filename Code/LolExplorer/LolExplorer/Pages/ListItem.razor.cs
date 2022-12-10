using Blazorise.DataGrid;
using LolExplorer.Modele;
using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;

namespace LolExplorer.Pages
{
    public partial class ListItem
    {
        private List<ItemApi> items;
        private int totalItem;

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public IStringLocalizer<ListItem> Localizer { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }



        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                return;
            }

            var currentData = await LocalStorage.GetItemAsync<ItemApi[]>("data");

            // Check if data exist in the local storage
            if (currentData == null)
            {
                // this code add in the local storage the fake data (we load the data sync for initialize the data before load the OnReadData method)
                var originalData = await Http.GetFromJsonAsync<ItemApi[]>($"{NavigationManager.BaseUri}apiLolItem.json");
                await LocalStorage.SetItemAsync("data", originalData);
            }
        }

        private async Task OnReadData(DataGridReadDataEventArgs<ItemApi> e)
        {
            if (e.CancellationToken.IsCancellationRequested)
            {
                return;
            }

            // When you use a real API, we use this follow code
            //var response = await Http.GetJsonAsync<Item[]>( $"http://my-api/api/data?page={e.Page}&pageSize={e.PageSize}" );
            var response = (await Http.GetFromJsonAsync<ItemApi[]>($"{NavigationManager.BaseUri}apiLolItem.json")).Skip((e.Page - 1) * e.PageSize).Take(e.PageSize).ToList();

            if (!e.CancellationToken.IsCancellationRequested)
            {
                totalItem = (await Http.GetFromJsonAsync<List<ItemApi>>($"{NavigationManager.BaseUri}apiLolItem.json")).Count;
                items = new List<ItemApi>(response); // an actual data for the current page
            }
        }
        
        


    }
    
}


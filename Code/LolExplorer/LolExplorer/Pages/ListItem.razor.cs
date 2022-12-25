using Blazorise.DataGrid;
using LolExplorer.Modele;
using LolExplorer;
using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using Blazored.Modal.Services;
using Blazored.Modal;
using LolExplorer.Modals;
using LolExplorer.Services;

namespace LolExplorer.Pages
{
    public partial class ListItem
    {

        private List<ItemApi> items =new();
        private int totalItem;

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }
        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }


        [Inject]
        public IStringLocalizer<ListItem> Localizer { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        [CascadingParameter]
        public IModalService Modal { get; set; }

        [Inject]
        public IDataService DataService { get; set; }


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

            if (!e.CancellationToken.IsCancellationRequested)
            {
                items = await DataService.List(e.Page, e.PageSize);
                totalItem = await DataService.Count();
            }
        }

        private async void OnDelete(int id)
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(ItemApi.Id), id);

            var modal = Modal.Show<DeleteConfirmation>("Delete Confirmation", parameters);
            var result = await modal.Result;

            if (result.Cancelled)
            {
                return;
            }

            await DataService.Delete(id);

            // Reload the page
            NavigationManager.NavigateTo("listitems", true);

        }

       

       
    }
    
}


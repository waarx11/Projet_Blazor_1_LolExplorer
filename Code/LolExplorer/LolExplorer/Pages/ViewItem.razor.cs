using LolExplorer.Components;
using LolExplorer.Modele;
using LolExplorer.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace LolExplorer.Pages
{
    public partial class ViewItem
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IStringLocalizer<ViewItem> Localizer { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        [Inject]
        public IDataService DataService { get; set; }

        private ItemApi ItemApi { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            ItemApi = await DataService.GetById(Id);
        }

       

        protected override async Task OnParametersSetAsync()
        {
            await OnInitializedAsync();
        }

    }
}

using LolExplorer.Factories;
using LolExplorer.Modele;
using LolExplorer.Services;
using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;

namespace LolExplorer.Components
{
    public partial class ItemDisplay
    {
        [Parameter]
        public int Id { get; set; } =-1;

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        [Inject]
        public IDataService DataService { get; set; }

        [Parameter]
        public ItemApi ItemApi { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            if(Id != -1)
                ItemApi = await DataService.GetById(Id);
        }
    }
}

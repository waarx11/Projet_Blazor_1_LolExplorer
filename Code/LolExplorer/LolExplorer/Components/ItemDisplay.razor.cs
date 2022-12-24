using LolExplorer.Factories;
using LolExplorer.Modele;
using LolExplorer.Services;
using Microsoft.AspNetCore.Components;

namespace LolExplorer.Components
{
    public partial class ItemDisplay
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        [Inject]
        public IDataService DataService { get; set; }

        private ItemApi ItemApi { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
           ItemApi = await DataService.GetById(Id); 
        }
    }
}

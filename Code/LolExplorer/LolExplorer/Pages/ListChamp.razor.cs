using LolExplorer.Modele;
using Microsoft.AspNetCore.Components;

namespace LolExplorer.Pages
{
    public partial class ListChamp
    {
        private ItemApi[] items;

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
    }
}

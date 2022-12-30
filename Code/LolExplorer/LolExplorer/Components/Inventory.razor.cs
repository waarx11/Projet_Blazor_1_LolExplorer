using Blazorise.DataGrid;
using Blazorise;
using LolExplorer.Modele;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using static System.Net.WebRequestMethods;
using LolExplorer.Pages;
using Microsoft.Extensions.Localization;

namespace LolExplorer.Components
{

    public partial class Inventory
    {
        [Parameter]
        public List<ItemApi> Items { get; set; }=new List<ItemApi>();


        [Inject]
        public IStringLocalizer<ListItem> Localizer { get; set; }
        [Parameter]
        public bool ResearcheBar { get; set; }=true;
        [Parameter]
        public bool LimitedList { get; set; } = false;
        private string SearchTerm { get; set; } = "";
        private int totalItem { get; set; }

        private const int pageSize= 10;
        private  int currentPage = 1;

        public void NextPage()
        {
            if(currentPage < ItemsSearched.Count()/ pageSize)
                currentPage++;
        }

        public void PreviosPage()
        {
            if(currentPage>1)
                currentPage--;
        }
        List<ItemApi> ItemsSearched => Items.AsEnumerable().Where( 
                    item  => 
                    item == null || 
                    ( item !=null &&
                    ( item.Name.ToLower().Contains(SearchTerm.ToLower()) || 
                      item.Tags.Any(i => i.ToLower().Contains(SearchTerm.ToLower()) ) ) //recherche par le tag
                    )
        ).ToList();
        List<ItemApi> currentData => ItemsSearched.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
       

    }
}

using LolExplorer.Modele;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace LolExplorer.Pages
{
    public partial class Index
    {
        [Inject]
        public IStringLocalizer<Index> Localizer { get; set; }
    }
}


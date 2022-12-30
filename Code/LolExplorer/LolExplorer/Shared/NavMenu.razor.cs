using LolExplorer.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace LolExplorer.Shared
{
    public partial class NavMenu
    {

        [Inject]
        public IStringLocalizer<NavMenu> Localizer { get; set; }
    }
}

using Blazorise.Extensions;
using LolExplorer.Modele;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace LolExplorer.Pages
{
    public partial class Index
    {
        [Inject]
        public IStringLocalizer<Index> Localizer { get; set; }

        private string TagContent;
        private List<string> Tags=new();
        void ajoutTag()
        {
            if (TagContent.IsNullOrEmpty() || !Tags.Contains(TagContent))
            {
                Tags.Add(TagContent);
            }
        }
    }
}


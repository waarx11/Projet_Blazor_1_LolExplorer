
using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Extensions;
using LolExplorer.Modele;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using LolExplorer.Services;
using Microsoft.Extensions.Localization;

namespace LolExplorer.Pages
{
    public partial class AddItem
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }
        [Inject]
        public IDataService DataService { get; set; }

        [Inject]
        public IStringLocalizer<EditItem> Localizer { get; set; }

        private ItemApiModel itemModel = new();
        private string TagContent;

        private async void HandleValidSubmit()
        {
            await DataService.Add(itemModel);

            NavigationManager.NavigateTo("listitems");
        }

        private async Task LoadImage(InputFileChangeEventArgs e)
        {
            // Set the content of the image to the model
            using (var memoryStream = new MemoryStream())
            {
                await e.File.OpenReadStream().CopyToAsync(memoryStream);
                itemModel.Icon = memoryStream.ToArray();
            }
        }

        void ajoutTag()
        {
            if (TagContent.IsNullOrEmpty() || !itemModel.Tags.Contains(TagContent))
            {
                itemModel.Tags.Add(TagContent);
            }
        }

    }
}





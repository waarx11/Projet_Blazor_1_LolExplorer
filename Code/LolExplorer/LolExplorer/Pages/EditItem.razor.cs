using Blazorise.Extensions;
using LolExplorer.Modele;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace LolExplorer.Pages
{
    public partial class EditItem
    {
        [Parameter]
        public int Id { get; set; }

        private bool loadedImage = false;

        [Inject]
        public IDataService DataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        private ItemApiModel itemModel = new();

        private string TagContent;

        protected override async Task OnInitializedAsync()
        {
            var item = await DataService.GetById(Id);

            // Set the model with the item
            itemModel = new ItemApiModel
            {
                Id = item.Id,
                Name = item.Name,
                Plaintext = item.Plaintext,
                Base = item.Price.Base,
                Total = item.Price.Total,
                Sell = item.Price.Sell,
                Purchasable = item.Purchasable,
                Tags = item.Tags,

            };
        }

        private async Task LoadImage(InputFileChangeEventArgs e)
        {
            // Set the content of the image to the model
            using (var memoryStream = new MemoryStream())
            {
                await e.File.OpenReadStream().CopyToAsync(memoryStream);
                itemModel.Icon = memoryStream.ToArray();
            }
            loadedImage=true;
        }

        private async void HandleValidSubmit()
        {
            if (!loadedImage)
            {
                itemModel.Icon = null;
                await DataService.Update(Id, itemModel);
            }
            else
            {
                await DataService.Update(Id, itemModel);
            }
            

            NavigationManager.NavigateTo("list");
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

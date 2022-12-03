using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Extensions;
using LolExplorer.Modele;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace LolExplorer.Pages
{
    public partial class AddItem
    {
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        private ItemApiModel itemModel=new() ;
        private string TagContent;

        private async void HandleValidSubmit()
        {
            // Get the current data
            var currentData = await LocalStorage.GetItemAsync<ItemApi[]>("data");

            // Simulate the Id
            itemModel.Id = currentData.Max(s => s.Id) + 1;

            // Add the item to the current data
            currentData[currentData.Length]=(new ItemApi
            {
                Id = itemModel.Id,
                Name = itemModel.Name,
                Plaintext =itemModel.Plaintext,
                Price=new Price(itemModel.Base, itemModel.Total, itemModel.Sell),
                Purchasable = itemModel.Purchasable,
            });

            // Save the image
            var imagePathInfo = new DirectoryInfo($"{WebHostEnvironment.WebRootPath}/images");

            // Check if the folder "images" exist
            if (!imagePathInfo.Exists)
            {
                imagePathInfo.Create();
            }

            // Determine the image name
            var fileName = new FileInfo($"{imagePathInfo}/{itemModel.Id}.png");

            // Write the file content
            await File.WriteAllBytesAsync(fileName.FullName, itemModel.Icon);

            // Save the data
            await LocalStorage.SetItemAsync("data", currentData);
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
            if(TagContent.IsNullOrEmpty() || !itemModel.Tags.Contains(TagContent))
            {
                itemModel.Tags.Add(TagContent);
            }
        }


    }
}


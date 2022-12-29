using Blazored.LocalStorage;
using Blazorise;
using LolExplorer.Components;
using LolExplorer.Factories;
using LolExplorer.Modele;
using Microsoft.AspNetCore.Components;
using System.Xml.Linq;

namespace LolExplorer.Services
{
    public class DataLocalService : IDataService
    {
    
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navigationManager;
        private readonly ItemFactory itemFactory;
        private readonly IWebHostEnvironment _webHostEnvironment;
    
        public DataLocalService(
            ILocalStorageService localStorage,
            HttpClient http,
            IWebHostEnvironment webHostEnvironment,
            NavigationManager navigationManager)
        {
            _localStorage = localStorage;
            _http = http;
            _webHostEnvironment = webHostEnvironment;
            _navigationManager = navigationManager;
        }

        public async Task Add(ItemApiModel itemModel)
        {
            // Get the current data
            var currentData = await _localStorage.GetItemAsync<List<ItemApi>>("data");

            // Simulate the Id
            itemModel.Id = currentData.Max(s => s.Id) + 1;

            // Add the item to the current data c
       

         /*   currentData.Add(new ItemApi
            {
                Id = itemModel.Id,
                Name = itemModel.Name,
                Plaintext = itemModel.Plaintext,
                Price = new Price(itemModel.Base, itemModel.Total, itemModel.Sell),
                Purchasable = itemModel.Purchasable,
                Icon= $"{imagePathInfo}/{itemModel.Name}.png",
                Tags=itemModel.Tags
            });*/

            currentData.Add(ItemFactory.Create(itemModel));

            await _localStorage.SetItemAsync("data", currentData);
        }

        public async Task<int> Count()
        {
            // Load data from the local storage
            var currentData = await _localStorage.GetItemAsync<ItemApi[]>("data");

            // Check if data exist in the local storage
            if (currentData == null)
            {
                // this code add in the local storage the fake data
                var originalData = await _http.GetFromJsonAsync<ItemApi[]>($"{_navigationManager.BaseUri}apiLolItem.json");
                await _localStorage.SetItemAsync("data", originalData);
            }

            return (await _localStorage.GetItemAsync<ItemApi[]>("data")).Length;
        }
    

        public async Task<List<ItemApi>> List(int currentPage, int pageSize)
        {
            // Load data from the local storage
            var currentData = await _localStorage.GetItemAsync<ItemApi[]>("data");

            // Check if data exist in the local storage
            if (currentData == null)
            {
                // this code add in the local storage the fake data
                var originalData = await _http.GetFromJsonAsync<ItemApi[]>($"{_navigationManager.BaseUri}apiLolItem.json");
                await _localStorage.SetItemAsync("data", originalData);
            }



            return (await _localStorage.GetItemAsync<ItemApi[]>("data")).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task<List<ItemApi>> List()
        {
            // Load data from the local storage
            var currentData = await _localStorage.GetItemAsync<ItemApi[]>("data");

            // Check if data exist in the local storage
            if (currentData == null)
            {
                // this code add in the local storage the fake data
                var originalData = await _http.GetFromJsonAsync<ItemApi[]>($"{_navigationManager.BaseUri}apiLolItem.json");
                await _localStorage.SetItemAsync("data", originalData);
            }



            return (await _localStorage.GetItemAsync<ItemApi[]>("data")).ToList();
        }


        public async Task<ItemApi> GetById(int id)
        {
            // Get the current data
            var currentData = await _localStorage.GetItemAsync<List<ItemApi>>("data");

            // Get the item int the list
            var item = currentData.FirstOrDefault(w => w.Id == id);

            // Check if item exist
            if (item == null)
            {
                throw new Exception($"Unable to found the item with ID: {id}");
            }

            return item;
        }

        public async Task Update(int id, ItemApiModel model)
        {
            // Get the current data
            var currentData = await _localStorage.GetItemAsync<List<ItemApi>>("data");

            // Get the item int the list
            var item = currentData.FirstOrDefault(w => w.Id == id);

            // Check if item exist
            if (item == null)
            {
                throw new Exception($"Unable to found the item with ID: {id}");
            }
           
            // Modify the content of the item
            /* item.Id = model.Id;
             item.Name = model.Name;
             item.Plaintext = model.Plaintext;
             item.Price = new Price(model.Base, model.Total, model.Sell);
             item.Purchasable = model.Purchasable;
             item.Tags = model.Tags;
     */
            ItemFactory.Update(item, model);

            // Save the data
            await _localStorage.SetItemAsync("data", currentData);
        }

        public async Task Delete(int id)
        {
            // Get the current data
            var currentData = await _localStorage.GetItemAsync<List<ItemApi>>("data");

            // Get the item int the list
            var item = currentData.FirstOrDefault(w => w.Id == id);

            // Delete item in
            currentData.Remove(item);

            // Delete the image
          

            // Save the data
            await _localStorage.SetItemAsync("data", currentData);
        }
        public async Task<List<CraftingRecipe>> GetRecipes()
        {
            List<CraftingRecipe> craftingRecipes = new();
            List<ItemApi> items = await _localStorage.GetItemAsync<List<ItemApi>>("data");
            foreach (var item in items)
            {
                CraftingRecipe craftingRecipe = new();
                craftingRecipe.Give = item;
                int cpt = 3;
                foreach (int i in item.From)
                {
                    craftingRecipe.Have.Add(i.ToString());
                    cpt--;
                }
                if (cpt > 0 && cpt != 3)
                {
                    for (int j = 0; j < cpt; j++)
                    {
                        craftingRecipe.Have.Add(null);
                    }
                }
                if (craftingRecipe.Have.Count > 0)
                {
                    craftingRecipes.Add(craftingRecipe);
                }
            }

            return craftingRecipes;

        }

        public Task AddInventory(List<ItemApi> items)
        {
            throw new NotImplementedException();
        }

        public Task<List<ItemApi>> AllInventory()
        {
            throw new NotImplementedException();
        }
        /*
Task<List<ItemApi>> IDataService.List(int currentPage, int pageSize)
{
throw new NotImplementedException();
}*/
    }
}
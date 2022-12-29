using LolExplorer.Components;
using LolExplorer.Factories;
using LolExplorer.Modele;
using LolExplorer.Services;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LolExplorer.Service
{
    public class DataApiService : IDataService
    {
        private readonly HttpClient _http;

        public DataApiService(
            HttpClient http)
        {
            _http = http;
        }

        public async Task Add(ItemApiModel model)
        {
            // Get the item
            var item = ItemFactory.Create(model);

            // Save the data
            await _http.PostAsJsonAsync("https://localhost:7234/api/Crafting/add", item);
        }

        public async Task AddInventory(List<ItemApi> items)
        {
            await _http.PostAsJsonAsync($"https://localhost:7234/api/Crafting/addInventory", items);
        }
        public async Task<int> Count()
        {
            return await _http.GetFromJsonAsync<int>("https://localhost:7234/api/Crafting/count");
        }

        public async Task<List<ItemApi>> List(int currentPage, int pageSize)
        {
            return await _http.GetFromJsonAsync<List<ItemApi>>($"https://localhost:7234/api/Crafting/?currentPage={currentPage}&pageSize={pageSize}");
        }

        public async Task<List<ItemApi>> AllInventory()
        {
            return await _http.GetFromJsonAsync<List<ItemApi>>($"https://localhost:7234/api/Crafting/inventory");
        }

        public async Task<ItemApi> GetById(int id)
        {
            return await _http.GetFromJsonAsync<ItemApi>($"https://localhost:7234/api/Crafting/{id}");
        }

        public async Task Update(int id, ItemApiModel model)
        {
            // Get the item
            ItemApi item = ItemFactory.Create(model);
            await _http.PutAsJsonAsync($"https://localhost:7234/api/Crafting/{id}", item);
        }
        
        public async Task Delete(int id)
        {
            await _http.DeleteAsync($"https://localhost:7234/api/Crafting/{id}");
        }

        public async Task<List<ItemApi>> List()
        {
            return await _http.GetFromJsonAsync<List<ItemApi>>("https://localhost:7234/api/Crafting/all"); ;
        }

        public async Task<List<CraftingRecipe>> GetRecipes()
        {
            List<CraftingRecipe> craftingRecipes = new();
            List<ItemApi> items = await _http.GetFromJsonAsync<List<ItemApi>>($"https://localhost:7234/api/Crafting/all");
            foreach(var item in items)
            {
                CraftingRecipe craftingRecipe = new();
                craftingRecipe.Give = item;
                foreach(int i in item.From) {
                    craftingRecipe.Have.Add(i.ToString());
              
                }
                
                if (craftingRecipe.Have.Count > 0)
                {
                    craftingRecipes.Add(craftingRecipe);
                }
                    



            }

            return craftingRecipes;

        }

      
    }
}

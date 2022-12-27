using LolExplorer.Factories;
using LolExplorer.Modele;
using LolExplorer.Services;

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
            await _http.PostAsJsonAsync("https://localhost:7234/api/Crafting/", item);
        }

        public async Task<int> Count()
        {
            return await _http.GetFromJsonAsync<int>("https://localhost:7234/api/Crafting/count");
        }

        public async Task<List<ItemApi>> List(int currentPage, int pageSize)
        {
            return await _http.GetFromJsonAsync<List<ItemApi>>($"https://localhost:7234/api/Crafting/?currentPage={currentPage}&pageSize={pageSize}");
        }



        public async Task<ItemApi> GetById(int id)
        {
            return await _http.GetFromJsonAsync<ItemApi>($"https://localhost:7234/api/Crafting/{id}");
        }

        public async Task Update(int id, ItemApiModel model)
        {
            // Get the item
            var item = ItemFactory.Create(model);

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
    }
}

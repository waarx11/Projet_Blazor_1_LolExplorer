using Blazored.LocalStorage;
using LolExplorer.Modele;
using Microsoft.AspNetCore.Components;

public class DataLocalService //: IDataService
{
    /*
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;
    private readonly NavigationManager _navigationManager;
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

    public async Task Add(ItemApiModel model)
    {
        // Get the current data
        var currentData = await _localStorage.GetItemAsync<List<Item>>("data");

        // Simulate the Id
        model.Id = currentData.Max(s => s.Id) + 1;

        // Add the item to the current data
        currentData.Add(new ItemApi
        {
            Id = itemModel.Id,
            Name = itemModel.Name,
            Plaintext = itemModel.Plaintext,
            Price = new Price(itemModel.Base, itemModel.Total, itemModel.Sell),
            Purchasable = itemModel.Purchasable,
        });

        // Save the image
        var imagePathInfo = new DirectoryInfo($"{_webHostEnvironment.WebRootPath}/images");

        // Check if the folder "images" exist
        if (!imagePathInfo.Exists)
        {
            imagePathInfo.Create();
        }

        // Determine the image name
        var fileName = new FileInfo($"{imagePathInfo}/{model.Name}.png");

        // Write the file content
        await File.WriteAllBytesAsync(fileName.FullName, model.ImageContent);

        // Save the data
        await _localStorage.SetItemAsync("data", currentData);
    }

    public async Task<int> Count()
    {
        // Load data from the local storage
        var currentData = await _localStorage.GetItemAsync<Item[]>("data");

        // Check if data exist in the local storage
        if (currentData == null)
        {
            // this code add in the local storage the fake data
            var originalData = await _http.GetFromJsonAsync<Item[]>($"{_navigationManager.BaseUri}fake-data.json");
            await _localStorage.SetItemAsync("data", originalData);
        }

        return (await _localStorage.GetItemAsync<Item[]>("data")).Length;
    }

    public Task<ItemApi> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ItemApi>> List(int currentPage, int pageSize)
    {
        // Load data from the local storage
        var currentData = await _localStorage.GetItemAsync<Item[]>("data");

        // Check if data exist in the local storage
        if (currentData == null)
        {
            // this code add in the local storage the fake data
            var originalData = await _http.GetFromJsonAsync<Item[]>($"{_navigationManager.BaseUri}fake-data.json");
            await _localStorage.SetItemAsync("data", originalData);
        }

        return (await _localStorage.GetItemAsync<Item[]>("data")).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
    }

    public Task Update(int id, ItemApiModel model)
    {
        throw new NotImplementedException();
    }

    Task<List<ItemApi>> IDataService.List(int currentPage, int pageSize)
    {
        throw new NotImplementedException();
    }*/
}
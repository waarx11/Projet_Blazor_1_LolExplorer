// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingController.cs" company="UCA Clermont-Ferrand">
//     Copyright (c) UCA Clermont-Ferrand All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Minecraft.Crafting.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Minecraft.Crafting.Api.Models;
    using System.Linq;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// The crafting controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CraftingController : ControllerBase
    {
        /// <summary>
        /// The json serializer options.
        /// </summary>
        private readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The async task.</returns>
        [HttpPost]
        [Route("")]
        public Task Add(ItemApi item)
        {
            var data = JsonSerializer.Deserialize<List<ItemApi>>(System.IO.File.ReadAllText("Data/items.json"), _jsonSerializerOptions);
            if (data == null)
            {
                throw new Exception("Unable to get the items.");
            }

            data.Add(item);

            System.IO.File.WriteAllText("Data/items.json", JsonSerializer.Serialize(data, _jsonSerializerOptions));

            return Task.CompletedTask;
        }

        /// <summary>
        /// Get all items.
        /// </summary>
        /// <returns>All items.</returns>
        [HttpGet]
        [Route("all")]
        public Task<List<ItemApi>> All()
        {
            var data = JsonSerializer.Deserialize<List<ItemApi>>(System.IO.File.ReadAllText("Data/Item.json"), _jsonSerializerOptions);

            if (data == null)
            {
                throw new Exception("Unable to get the items.");
            }

            return Task.FromResult(data.ToList());
        }

        /// <summary>
        /// Count the number of items.
        /// </summary>
        /// <returns>The number of items.</returns>
        [HttpGet]
        [Route("count")]
        public Task<int> Count()
        {
            var data = JsonSerializer.Deserialize<List<ItemApi>>(System.IO.File.ReadAllText("Data/items.json"), _jsonSerializerOptions);

            if (data == null)
            {
                throw new Exception("Unable to get the items.");
            }

            return Task.FromResult(data.Count);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The async task.</returns>
        [HttpDelete]
        [Route("{id}")]
        public Task Delete(int id)
        {
            var data = JsonSerializer.Deserialize<List<ItemApi>>(System.IO.File.ReadAllText("Data/items.json"), _jsonSerializerOptions);

            if (data == null)
            {
                throw new Exception("Unable to get the items.");
            }

            var item = data.FirstOrDefault(w => w.Id == id);

            if (item == null)
            {
                throw new Exception($"Unable to found the item with ID: {id}");
            }
            data.Where(i => i.From.Contains(item.Id)).ToList().ForEach(i => i.From.Remove(item.Id));
            data.Where(i => i.Into.Contains(item.Id)).ToList().ForEach(i => i.Into.Remove(item.Id));
            data.Remove(item);

            System.IO.File.WriteAllText("Data/items.json", JsonSerializer.Serialize(data, _jsonSerializerOptions));

            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets the item by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The item.</returns>
        [HttpGet]
        [Route("{id}")]
        public Task<ItemApi> GetById(int id)
        {
            var data = JsonSerializer.Deserialize<List<ItemApi>>(System.IO.File.ReadAllText("Data/items.json"), _jsonSerializerOptions);

            if (data == null)
            {
                throw new Exception("Unable to get the items.");
            }

            var item = data.FirstOrDefault(w => w.Id == id);

            if (item == null)
            {
                throw new Exception($"Unable to found the item with ID: {id}");
            }

            return Task.FromResult(item);
        }

        /// <summary>
        /// Gets the item by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        /// The item.
        /// </returns>
        [HttpGet]
        [Route("by-name/{name}")]
        public Task<ItemApi> GetByName(string name)
        {
            var data = JsonSerializer.Deserialize<List<ItemApi>>(System.IO.File.ReadAllText("Data/items.json"), _jsonSerializerOptions);

            if (data == null)
            {
                throw new Exception("Unable to get the items.");
            }

            var item = data.FirstOrDefault(w => w.Name.ToLowerInvariant() == name.ToLowerInvariant());

            if (item == null)
            {
                throw new Exception($"Unable to found the item with name: {name}");
            }

            return Task.FromResult(item);
        }


        /// <summary>
        /// Get the items with pagination.
        /// </summary>
        /// <param name="currentPage">The current page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>The items.</returns>
        [HttpGet]
        [Route("")]
        public Task<List<ItemApi>> List(int currentPage, int pageSize)
        {
            var data = JsonSerializer.Deserialize<List<ItemApi>>(System.IO.File.ReadAllText("Data/items.json"), _jsonSerializerOptions);

            if (data == null)
            {
                throw new Exception("Unable to get the items.");
            }

            return Task.FromResult(data.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList());
        }




       

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <returns>The async task.</returns>
        [HttpPut]
        [Route("{id}")]
        public Task Update(int id, [FromBody]  ItemApi item)
        {
            var data = JsonSerializer.Deserialize<List<ItemApi>>(System.IO.File.ReadAllText("Data/items.json"), _jsonSerializerOptions);

            var itemOriginal = data?.FirstOrDefault(w => w.Id == id);

            if (itemOriginal == null)
            {
                throw new Exception($"Unable to found the item with ID: {id}");
            }

            itemOriginal.Id = item.Id;
            itemOriginal.Name = item.Name;
            itemOriginal.Tags = item.Tags;
            itemOriginal.Icon = item.Icon;
            itemOriginal.Price= new Price(item.Price.Base, item.Price.Total, item.Price.Sell);
            itemOriginal.Purchasable= item.Purchasable ;
            itemOriginal.From= item.From;
            itemOriginal.Plaintext= item.Plaintext;

            System.IO.File.WriteAllText("Data/items.json", JsonSerializer.Serialize(data, _jsonSerializerOptions));

            return Task.CompletedTask;
        }

      

        /// <summary>
        /// Gets the name of the item.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>The name of the item.</returns>
        private static string GetItemName(List<ItemApi> items, long id)
        {
            var item = items.FirstOrDefault(w => w.Id == id);
            return item?.Name;
        }

    }
}
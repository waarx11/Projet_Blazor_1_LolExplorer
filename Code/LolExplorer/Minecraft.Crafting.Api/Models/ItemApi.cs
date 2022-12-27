// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InventoryController.cs" company="UCA Clermont-Ferrand">
//     Copyright (c) UCA Clermont-Ferrand All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Minecraft.Crafting.Api.Models
{
    /// <summary>
    /// The item.
    /// </summary>
    public class ItemApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemApi"/> class.
        /// </summary>
        public ItemApi()
        {
            From = new List<int>();
            Into = new List<int>();
            Tags = new List<string>();
        }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("plaintext")]
        public string Plaintext { get; set; }
        [JsonPropertyName("into")]
        public List<int> Into { get; set; }
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("price")]
        public Price Price { get; set; }
        [JsonPropertyName("purchasable")]
        public bool Purchasable { get; set; }
        [JsonPropertyName("from")]
        public List<int> From { get; set; }
    }
}
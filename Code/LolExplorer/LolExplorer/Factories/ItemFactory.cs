using LolExplorer.Modele;
using Microsoft.AspNetCore.Hosting;

namespace LolExplorer.Factories
{
    public class ItemFactory
    {

        public static ItemApiModel ToModel(ItemApi item, byte[] imageContent)
        {
            return new ItemApiModel
            {
                Id = item.Id,
                Name = item.Name,
                Plaintext = item.Plaintext,
                Base = item.Price.Base,
                Total = item.Price.Total,
                Sell = item.Price.Sell,
                Purchasable = item.Purchasable,
                Tags = item.Tags,
                Icon= imageContent,
                ImageBase64 = string.IsNullOrWhiteSpace(item.Icon) ? Convert.ToBase64String(imageContent) : item.Icon
            };
        }

        public static ItemApi Create(ItemApiModel model)
        {
            string image;
            if (model.Icon == null)
            {
                image = model.ImageBase64;
            }
            else {
                image = Convert.ToBase64String(model.Icon);
            }
            Price price = new Price(model.Base, model.Total, model.Sell);
            return new ItemApi
            {
                Id = model.Id,
                Name = model.Name,
                Plaintext = model.Plaintext,
                Price = price,
                Purchasable = model.Purchasable,
                Icon = image,
                Tags = model.Tags
            };
        }

        public static void Update(ItemApi item, ItemApiModel model)
        {
            item.Id = model.Id;
            item.Name = model.Name;
            item.Plaintext = model.Plaintext;
            item.Price = new Price(model.Base, model.Total, model.Sell);
            item.Purchasable = model.Purchasable;
            item.Tags = model.Tags;
            if(model.Icon!= null)
            {
                item.Icon = Convert.ToBase64String(model.Icon);
            }
            
        }
    }
}

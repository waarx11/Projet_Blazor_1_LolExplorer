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
                Icon= imageContent
            };
        }

        public static ItemApi Create(ItemApiModel model,string imgPth)
        {   
            return new ItemApi
            {
                Id = model.Id,
                Name = model.Name,
                Plaintext = model.Plaintext,
                Price = new Price(model.Base, model.Total, model.Sell),
                Purchasable = model.Purchasable,
                Icon = imgPth,
                Tags = model.Tags
            };
        }

        public static void Update(ItemApi item, ItemApiModel model,string imagePath)
        {
            item.Id = model.Id;
            item.Name = model.Name;
            item.Plaintext = model.Plaintext;
            item.Price = new Price(model.Base, model.Total, model.Sell);
            item.Purchasable = model.Purchasable;
            item.Tags = model.Tags;
            if(imagePath!=null) item.Icon = imagePath;
        }
    }
}

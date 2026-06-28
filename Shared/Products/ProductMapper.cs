using System.Collections.ObjectModel;
using Shared.Infrastructure;
using Shared.Utils;

namespace Shared.Products;

public sealed class ProductMapper : Mapper<ProductModel, ProductEntity>
{
    public override ProductEntity MapToEntity(ProductModel model)
    {
        var entity = base.MapToEntity(model);
        entity.Name = model.Name;
        entity.Description = model.Description;
        entity.ImageUrls = model.ImageUrls.Select(url => url.ToString()).ToArray();
        entity.Price = model.Price;
        entity.Amount = model.Amount;
        entity.Characteristics = model.Characteristics.ToDictionary();
        entity.SellerId = model.SellerId;
        return entity;
    }

    public override ProductModel MapToModel(ProductEntity entity) =>
        base.MapToModel(entity) with
        {
            Name = entity.Name,
            Description = entity.Description,
            ImageUrls = entity.ImageUrls.Select(url => url.ToUri()!).ToArray(),
            Price = entity.Price,
            Amount = entity.Amount,
            Characteristics = new ReadOnlyDictionary<string, string>(entity.Characteristics),
            SellerId = entity.SellerId
        };
}
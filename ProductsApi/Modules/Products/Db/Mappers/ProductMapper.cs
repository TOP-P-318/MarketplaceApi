using System.Collections.ObjectModel;
using ProductsApi.Core.Infrastructure.Db.Mappers;
using ProductsApi.Core.Utils;
using ProductsApi.Modules.Products.Db.Entities;
using ProductsApi.Modules.Products.Domain.Models;

namespace ProductsApi.Modules.Products.Db.Mappers;

public sealed class ProductMapper : MapperBase<ProductModel, ProductEntity>
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
        };
}
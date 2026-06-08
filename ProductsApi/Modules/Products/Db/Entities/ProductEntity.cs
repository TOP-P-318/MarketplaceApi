using ProductsApi.Core.Infrastructure.Db.Entities;

namespace ProductsApi.Modules.Products.Db.Entities;

public sealed class ProductEntity : EntityBase<ProductEntity>
{
    public string Name { get; set; } = string.Empty;

    public override void Update(ProductEntity entity)
    {
        Name = entity.Name;
    }
}
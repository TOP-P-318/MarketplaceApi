using System.Collections.ObjectModel;
using System.Numerics;
using ProductsApi.Core.Infrastructure.Db.Entities;

namespace ProductsApi.Modules.Products.Db.Entities;

public sealed class ProductEntity : EntityBase<ProductEntity>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string[] ImageUrls { get; set; } = [];
    public BigInteger Price { get; set; }
    public int Amount { get; set; }
    public Dictionary<string, string> Characteristics { get; set; } = new();

    public override void Update(ProductEntity other)
    {
        base.Update(other);
        Name = other.Name;
        ImageUrls = other.ImageUrls;
        Price = other.Price;
        Amount = other.Amount;
        Description = other.Description;
        Characteristics = other.Characteristics;
    }
}
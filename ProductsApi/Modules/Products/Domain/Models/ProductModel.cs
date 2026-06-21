using System.Collections.ObjectModel;
using System.Numerics;
using ProductsApi.Core.Infrastructure.Domain.Models;

namespace ProductsApi.Modules.Products.Domain.Models;

public sealed record ProductModel : ModelBase
{
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public Uri[] ImageUrls { get; init; } = [];
    public BigInteger Price { get; init; }
    public int Amount { get; init; }
    public ReadOnlyDictionary<string, string> Characteristics { get; init; } = new(new Dictionary<string, string>());


    public ProductModel WithUpdatedName(string name) =>
        Touch<ProductModel>() with
        {
            Name = name
        };

    // TODO: написать методы для Update;
}
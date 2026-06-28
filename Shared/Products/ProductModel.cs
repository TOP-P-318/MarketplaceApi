using System.Collections.ObjectModel;
using System.Numerics;
using Shared.Infrastructure;

namespace Shared.Products;

public sealed record ProductModel : Model
{
    public Guid SellerId { get; init; }
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

    public ProductModel WithDecAmount() =>
        Touch<ProductModel>() with
        {
            Amount = Amount - 1
        };

    // TODO: написать методы для Update;
}
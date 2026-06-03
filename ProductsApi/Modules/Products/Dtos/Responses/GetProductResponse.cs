using ProductsApi.Modules.Products.Domain.Models;

namespace ProductsApi.Modules.Products.Dtos.Responses;

public sealed class GetProductResponse
{
    public string Name { get; private init; } = string.Empty;

    public static GetProductResponse CreateFrom(ProductModel product) => new() { Name = product.Name };
}
using ProductsApi.Modules.Products.Domain.Models;
using ProductsApi.Modules.Products.Dtos.Requests;

namespace ProductsApi.Modules.Products.Domain.Mappers;

public sealed class ProductMapper : IProductMapper
{
    public ProductModel ToModelFrom(AddProductRequest request) =>
        new()
        {
            Name = request.Name
        };
}
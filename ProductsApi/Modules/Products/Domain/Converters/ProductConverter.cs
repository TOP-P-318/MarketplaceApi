using ProductsApi.Modules.Products.Domain.Models;
using ProductsApi.Modules.Products.Dtos.Requests;
using ProductsApi.Modules.Products.Dtos.Responses;

namespace ProductsApi.Modules.Products.Domain.Converters;

public static class ProductConverter
{
    extension(ProductModel product)
    {
        public GetProductResponse ConvertToGetProductResponse() =>
            new()
            {
                Id = product.Id,
                Name = product.Name,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };

        public CreateProductResponse ConvertToCreateProductResponse() =>
            new()
            {
                Id = product.Id,
                CreatedAt = product.CreatedAt
            };

        public UpdateProductResponse ConvertToUpdateProductResponse() =>
            new()
            {
                UpdatedAt = product.UpdatedAt
            };
    }

    public static ProductModel ConvertToProductModel(this CreateProductRequest request) =>
        new()
        {
            Name = request.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

    public static ProductModel ConvertToProductModel(this UpdateProductRequest request, Guid id) =>
        new ProductModel
        {
            Id = id
        }.WithUpdatedName(request.Name);
}
using ProductsApi.Modules.Products.Requests;
using ProductsApi.Modules.Products.Responses;
using Shared.Products;

namespace ProductsApi.Products;

public static class ProductConverter
{
    extension(ProductModel product)
    {
        public GetProductPreviewResponse ConvertToGetProductPreviewResponse() =>
            new()
            {
                Id = product.Id,
                Name = product.Name,
                PreviewUrl = product.ImageUrls.FirstOrDefault()?.ToString(),
                Amount = product.Amount,
                Price = product.Price.ToString(),
            };

        public GetProductDetailsResponse ConvertToGetProductDetailsResponse() =>
            new()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrls = product.ImageUrls.Select(url => url.ToString()),
                Amount = product.Amount,
                Price = product.Price.ToString(),
                Characteristics = product.Characteristics,
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
            }
            .WithUpdatedName(request.Name);
}
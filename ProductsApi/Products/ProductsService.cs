using ProductsApi.Modules.Products;
using ProductsApi.Modules.Products.Requests;
using ProductsApi.Modules.Products.Responses;
using Shared.Products;

namespace ProductsApi.Products;

public sealed class ProductsService(ProductsRepo productsRepo)
{
    public async Task<GetProductDetailsResponse?> GetDetailsAsync(Guid id)
    {
        var product = await productsRepo.FindByIdAsync(id);
        return product?.ConvertToGetProductDetailsResponse();
    }

    public async Task<IEnumerable<GetProductPreviewResponse>> GetPreviewsAsync()
    {
        var products = await productsRepo.FindAllAsync();
        return products.Select(ProductConverter.ConvertToGetProductPreviewResponse);
    }

    public async Task<CreateProductResponse> AddAsync(CreateProductRequest request)
    {
        var product = request.ConvertToProductModel();
        await productsRepo.AddAsync(product);
        return product.ConvertToCreateProductResponse();
    }

    public async Task<UpdateProductResponse> UpdateAsync(UpdateProductRequest request, Guid id)
    {
        var product = request.ConvertToProductModel(id);
        await productsRepo.UpdateAsync(product);
        return product.ConvertToUpdateProductResponse();
    }

    public async Task RemoveAsync(Guid id) => await productsRepo.RemoveByIdAsync(id);
}
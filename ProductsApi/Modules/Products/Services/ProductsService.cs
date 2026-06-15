using ProductsApi.Modules.Products.Db.Repos;
using ProductsApi.Modules.Products.Domain.Converters;
using ProductsApi.Modules.Products.Domain.Models;
using ProductsApi.Modules.Products.Dtos.Requests;
using ProductsApi.Modules.Products.Dtos.Responses;

namespace ProductsApi.Modules.Products.Services;

public sealed class ProductsService(IProductsRepo productsRepo) : IProductsService
{
    public async Task<GetProductResponse?> GetAsync(Guid id)
    {
        var product = await productsRepo.FindByIdAsync(id);
        return product?.ConvertToGetProductResponse();
    }

    public async Task<IEnumerable<GetProductResponse>> GetAllAsync()
    {
        var products = await productsRepo.FindAllAsync();
        return products.Select(ProductConverter.ConvertToGetProductResponse);
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
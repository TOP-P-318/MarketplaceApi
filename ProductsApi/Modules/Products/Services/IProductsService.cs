using ProductsApi.Modules.Products.Dtos.Requests;
using ProductsApi.Modules.Products.Dtos.Responses;

namespace ProductsApi.Modules.Products.Services;

public interface IProductsService
{
    Task<GetProductResponse?> GetAsync(Guid id);
    Task<IEnumerable<GetProductResponse>> GetAllAsync();
    Task<CreateProductResponse> AddAsync(CreateProductRequest request);
    Task<UpdateProductResponse> UpdateAsync(UpdateProductRequest request, Guid id);
    Task RemoveAsync(Guid id);
}
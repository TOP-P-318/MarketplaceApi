using ProductsApi.Modules.Products.Dtos.Requests;
using ProductsApi.Modules.Products.Dtos.Responses;

namespace ProductsApi.Modules.Products.Services;

public interface IProductsService
{
    Task<GetProductDetailsResponse?> GetDetailsAsync(Guid id);
    Task<IEnumerable<GetProductPreviewResponse>> GetPreviewsAsync();
    Task<CreateProductResponse> AddAsync(CreateProductRequest request);
    Task<UpdateProductResponse> UpdateAsync(UpdateProductRequest request, Guid id);
    Task RemoveAsync(Guid id);
}
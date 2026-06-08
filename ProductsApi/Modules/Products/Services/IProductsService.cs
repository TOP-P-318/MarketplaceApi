using ProductsApi.Modules.Products.Domain.Models;

namespace ProductsApi.Modules.Products.Services;

public interface IProductsService
{
    Task<ProductModel?> GetAsync(Guid id);
    Task<IEnumerable<ProductModel>> GetAllAsync();
    Task AddAsync(ProductModel product);
    Task UpdateAsync(ProductModel product);
    Task RemoveAsync(Guid id);
}
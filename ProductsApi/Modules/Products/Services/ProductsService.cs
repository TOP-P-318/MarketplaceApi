using ProductsApi.Modules.Products.Db.Repos;
using ProductsApi.Modules.Products.Domain.Models;

namespace ProductsApi.Modules.Products.Services;

public sealed class ProductsService(IProductsRepo productsRepo) : IProductsService
{
    public async Task<ProductModel?> GetAsync(Guid id) => await productsRepo.FindByIdAsync(id);

    public async Task<IEnumerable<ProductModel>> GetAllAsync() => await productsRepo.FindAllAsync();

    public async Task AddAsync(ProductModel product) => await productsRepo.AddAsync(product);
    
    public async Task UpdateAsync(ProductModel product) => await productsRepo.UpdateAsync(product);
    public async Task RemoveAsync(Guid id) => await productsRepo.RemoveByIdAsync(id);
}
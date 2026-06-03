using ProductsApi.Modules.Products.Domain.Models;
using ProductsApi.Modules.Products.Dtos.Requests;

namespace ProductsApi.Modules.Products.Domain.Mappers;

public interface IProductMapper
{
    ProductModel ToModelFrom(AddProductRequest request);
}
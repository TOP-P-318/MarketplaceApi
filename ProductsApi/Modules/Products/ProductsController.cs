using Microsoft.AspNetCore.Mvc;
using ProductsApi.Modules.Products.Dtos.Responses;
using ProductsApi.Modules.Products.Services;

namespace ProductsApi.Modules.Products;

[ApiController]
[Route("api/products")]
public sealed class ProductsController(IProductsService productsService) : ControllerBase
{
    [HttpGet]
    [Route("all")]
    public async Task<ActionResult<IEnumerable<GetProductResponse>>> GetAllAsync()
    {
        var products = await productsService.GetAllAsync();
        return Ok(products.Select(GetProductResponse.CreateFrom));
    }
}
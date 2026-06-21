using Microsoft.AspNetCore.Mvc;
using ProductsApi.Core.Constants;
using ProductsApi.Modules.Products.Dtos.Responses;
using ProductsApi.Modules.Products.Services;

namespace ProductsApi.Modules.Products;

[ApiController]
[Route("api/products")]
public sealed class ProductsController(IProductsService productsService) : ControllerBase
{
    [HttpGet("previews", Name = Routes.Products.Name.GetPreviews)]
    public async Task<ActionResult<IEnumerable<GetProductPreviewResponse>>> GetPreviewsAsync()
    {
        var response = await productsService.GetPreviewsAsync();
        return Ok(response);
    }
}
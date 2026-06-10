using Microsoft.AspNetCore.Mvc;
using ProductsApi.Modules.Products.Dtos.Requests;
using ProductsApi.Modules.Products.Dtos.Responses;
using ProductsApi.Modules.Products.Services;

namespace ProductsApi.Modules.Products;

[ApiController]
[Route("api/product")]
public sealed class ProductController(IProductsService productsService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> AddAsync([FromBody] AddProductRequest request)
    {
        var product = request.ConvertToModel();
        await productsService.AddAsync(product);
        return Created();
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ActionResult<GetProductResponse>> GetAsync([FromRoute] Guid id)
    {
        var product = await productsService.GetAsync(id);
        if (product == null) return NotFound();
        return Ok(GetProductResponse.CreateFrom(product));
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<ActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateProductRequest request)
    {
        var product = request.ConvertToModel(id);
        try
        {
            await productsService.UpdateAsync(product);
            return Ok();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
    
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<ActionResult> RemoveAsync([FromRoute] Guid id)
    {
        try
        {
            await productsService.RemoveAsync(id);
            return Ok();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
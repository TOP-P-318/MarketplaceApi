using Microsoft.AspNetCore.Mvc;
using ProductsApi.Core.Constants;
using ProductsApi.Modules.Products.Dtos.Requests;
using ProductsApi.Modules.Products.Dtos.Responses;
using ProductsApi.Modules.Products.Services;

namespace ProductsApi.Modules.Products;

[ApiController]
[Route("api/product")]
public sealed class ProductController(IProductsService productsService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateProductResponse>> CreateAsync([FromBody] CreateProductRequest request)
    {
        var response = await productsService.AddAsync(request);
        return CreatedAtRoute(Routes.Product.Name.Get, new { id = response.Id }, response);
    }

    [HttpGet("{id:guid}", Name = Routes.Product.Name.Get)]
    public async Task<ActionResult<GetProductDetailsResponse>> GetAsync([FromRoute] Guid id)
    {
        var response = await productsService.GetDetailsAsync(id);
        if (response == null) return NotFound();
        return Ok(response);
    }

    [HttpPut("{id:guid}",  Name = Routes.Product.Name.Update)]
    public async Task<ActionResult<UpdateProductResponse>> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateProductRequest request)
    {
        try
        {
            var response = await productsService.UpdateAsync(request, id);
            return Ok(response);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:guid}", Name =  Routes.Product.Name.Delete)]
    public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
    {
        try
        {
            await productsService.RemoveAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
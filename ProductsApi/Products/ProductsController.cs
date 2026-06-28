using Microsoft.AspNetCore.Mvc;
using ProductsApi.Constants;
using ProductsApi.Modules.Products.Requests;
using ProductsApi.Modules.Products.Responses;

namespace ProductsApi.Products;

[ApiController]
[Route("api/products")]
public sealed class ProductsController(ProductsService productsService) : ControllerBase
{
    [HttpGet("previews", Name = Routes.Products.Name.GetPreviews)]
    public async Task<ActionResult<IEnumerable<GetProductPreviewResponse>>> GetPreviewsAsync()
    {
        var response = await productsService.GetPreviewsAsync();
        return Ok(response);
    }
    
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
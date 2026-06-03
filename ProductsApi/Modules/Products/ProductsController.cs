using Microsoft.AspNetCore.Mvc;
using ProductsApi.Core.Constants.Responses;
using ProductsApi.Modules.Products.Domain.Mappers;
using ProductsApi.Modules.Products.Domain.Models;
using ProductsApi.Modules.Products.Dtos.Requests;
using ProductsApi.Modules.Products.Dtos.Responses;

namespace ProductsApi.Modules.Products;

[ApiController]
[Route("api/products")]
public sealed class ProductsController(IProductMapper productMapper) : ControllerBase
{
    private static readonly SortedSet<ProductModel> Products =
    [
        new() { Name = "Какой-то продукт" },
        new() { Name = "Другой продукт" },
        new() { Name = "Еще один продукт" },
        new() { Name = "... продукт" },
        new() { Name = "Какой-то продукт" },
        new() { Name = "Какой-то другой продукт" },
    ];

    [HttpGet]
    [Route("all")]
    public async Task<ActionResult<IEnumerable<GetProductResponse>>> GetAllAsync()
    {
        var response = Products.Select(GetProductResponse.CreateFrom).ToList();
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync([FromBody] AddProductRequest request)
    {
        var product = productMapper.ToModelFrom(request);
        if (!Products.Add(product))
            return BadRequest(ResponseMessages.Products.BadRequest.AlreadyExists);
        return Ok();
    }
}
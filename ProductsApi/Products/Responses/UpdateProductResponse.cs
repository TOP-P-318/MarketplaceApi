namespace ProductsApi.Modules.Products.Responses;

public sealed record UpdateProductResponse
{
    public required DateTime UpdatedAt { get; init; }
}
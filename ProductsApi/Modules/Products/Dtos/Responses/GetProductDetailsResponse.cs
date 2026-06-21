using System.Numerics;

namespace ProductsApi.Modules.Products.Dtos.Responses;

public sealed record GetProductDetailsResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required IEnumerable<string> ImageUrls { get; init; }
    public string? Description { get; init; }
    public required string Price { get; init; }
    public required int Amount { get; init; }
    public required IReadOnlyDictionary<string, string> Characteristics { get; init; }
}
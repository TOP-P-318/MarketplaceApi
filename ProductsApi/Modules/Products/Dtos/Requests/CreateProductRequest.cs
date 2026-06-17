using System.ComponentModel.DataAnnotations;
using ProductsApi.Core.Constants;

namespace ProductsApi.Modules.Products.Dtos.Requests;

public sealed record CreateProductRequest
{
    [Required]
    [StringLength(Limits.Product.Name.MaxLength)]
    [MinLength(Limits.Product.Name.MinLength)]
    public required string Name { get; init; } = string.Empty;
    public string? PreviewUrl { get; init; }
}
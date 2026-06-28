using System.ComponentModel.DataAnnotations;
using Shared.Constants;

namespace ProductsApi.Modules.Products.Requests;

public sealed record UpdateProductRequest
{
    [Required]
    [MaxLength(Limits.Product.Name.MaxLength)]
    [MinLength(Limits.Product.Name.MinLength)]
    public required string Name { get; init; } = string.Empty;
}
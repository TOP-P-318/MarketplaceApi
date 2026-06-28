using System.ComponentModel.DataAnnotations;
using Shared.Constants;

namespace ProductsApi.Modules.Products.Requests;

public sealed record CreateProductRequest
{
    [Required]
    [StringLength(Limits.Product.Name.MaxLength)]
    [MinLength(Limits.Product.Name.MinLength)]
    public required string Name { get; init; } = string.Empty;
}
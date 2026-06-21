using System.ComponentModel.DataAnnotations;
using ProductsApi.Core.Constants;
using ProductsApi.Modules.Products.Domain.Models;

namespace ProductsApi.Modules.Products.Dtos.Requests;

public sealed record UpdateProductRequest
{
    [Required]
    [MaxLength(Limits.Product.Name.MaxLength)]
    [MinLength(Limits.Product.Name.MinLength)]
    public required string Name { get; init; } = string.Empty;
}
using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Modules.Products.Dtos.Requests;

public sealed class AddProductRequest
{
    [Required] public string Name { get; set; } = string.Empty;
}
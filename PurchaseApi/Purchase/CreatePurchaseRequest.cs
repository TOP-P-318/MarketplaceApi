using System.ComponentModel.DataAnnotations;

namespace PurchaseApi.Purchase.Requests;

public sealed record CreatePurchaseRequest
{
    [Required]
    public required Guid ProductId { get; init; }
}
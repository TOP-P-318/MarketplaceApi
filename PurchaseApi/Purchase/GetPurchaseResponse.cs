namespace PurchaseApi.Purchase.Responses;

public sealed record GetPurchaseResponse
{
    public required Guid ProductId { get; init; }
    public required Guid BuyerId { get; init; }
    public required string PricePaid { get; init; }
}
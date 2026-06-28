using System.Numerics;
using Shared.Infrastructure;

namespace Shared.Purchases;

public sealed record PurchaseModel : Model
{
    public Guid ProductId { get; init; }
    public Guid BuyerId { get; init; }
    public BigInteger PricePaid { get; init; }
}
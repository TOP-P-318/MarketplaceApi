using PurchaseApi.Purchase.Responses;
using Shared.Purchases;

namespace PurchaseApi.Purchase;

public static class PurchaseConverter
{
    public static GetPurchaseResponse ConvertToGetPurchaseResponse(this PurchaseModel purchase) => new()
    {
        BuyerId = purchase.BuyerId,
        PricePaid = purchase.PricePaid.ToString(),
        ProductId = purchase.ProductId,
    };
}
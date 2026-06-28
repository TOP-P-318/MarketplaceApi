using Shared.Infrastructure;

namespace Shared.Purchases;

public sealed class PurchaseMapper : Mapper<PurchaseModel, PurchaseEntity>
{
    public override PurchaseModel MapToModel(PurchaseEntity entity)
    {
        return base.MapToModel(entity) with
        {
            BuyerId = entity.BuyerId,
            ProductId = entity.ProductId,
            PricePaid = entity.PricePaid
        };
    }

    public override PurchaseEntity MapToEntity(PurchaseModel model)
    {
        var entity = base.MapToEntity(model);
        entity.BuyerId = model.BuyerId;
        entity.ProductId = model.ProductId;
        entity.PricePaid = model.PricePaid;
        return entity;
    }
}
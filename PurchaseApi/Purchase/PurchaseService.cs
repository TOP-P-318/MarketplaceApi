using PurchaseApi.Purchase.Requests;
using PurchaseApi.Purchase.Responses;
using Shared.Infrastructure;
using Shared.Products;
using Shared.Purchases;
using Shared.Users;

namespace PurchaseApi.Purchase;

public sealed class PurchaseService(
    TransactionManager transactionManager,
    PurchasesRepo purchasesRepo,
    ProductsRepo productsRepo,
    UsersRepo usersRepo)
{
    public async Task<GetPurchaseResponse?> GetPurchaseAsync(Guid id)
    {
        var purchase = await purchasesRepo.FindByIdAsync(id);
        return purchase?.ConvertToGetPurchaseResponse();
    }

    public async Task<Guid> CreatePurchaseAsync(CreatePurchaseRequest request, Guid buyerId)
    {
        await using var transaction = await transactionManager.BeginTransactionAsync();

        try
        {
            var product = await productsRepo.FindByIdWithLockAsync(request.ProductId);
            if (product == null) throw new KeyNotFoundException($"Product with id {request.ProductId} does not exist");
            if (product.Amount == 0)
                throw new InvalidOperationException($"Product with id {request.ProductId} sold out");

            var buyer = await usersRepo.FindByIdWithLockAsync(buyerId);
            if (buyer == null) throw new KeyNotFoundException($"Buyer with id {buyerId} does not exist");
            if (buyer.Balance < product.Price)
                throw new InvalidOperationException($"User with id {buyerId} does not have enough money");

            var seller = await usersRepo.FindByIdWithLockAsync(product.SellerId);
            if (seller == null) throw new KeyNotFoundException($"Seller with id {product.SellerId} does not exist");

            buyer = buyer.WithDecBalance(product.Price);
            seller = seller.WithIncBalance(product.Price);
            product = product.WithDecAmount();

            var purchase = new PurchaseModel
            {
                BuyerId = buyerId,
                ProductId = request.ProductId,
                PricePaid = product.Price,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await productsRepo.UpdateAsync(product);
            await usersRepo.UpdateAsync(seller);
            await usersRepo.UpdateAsync(buyer);
            await purchasesRepo.AddAsync(purchase);

            await transaction.CommitAsync();
            return purchase.Id;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Shared.Infrastructure;
using Shared.Products;
using Shared.Users;

namespace Shared.Purchases;

[Table("purchases")]
public class PurchaseEntity : Entity<PurchaseEntity>
{
    [Required]
    [Column("product_id")]
    public Guid ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public ProductEntity? Product { get; set; }
    
    [Required]
    [Column("buyer_id")]
    public Guid BuyerId { get; set; }
    [ForeignKey(nameof(BuyerId))]
    public UserEntity? Buyer { get; set; }
    
    [Required]
    [Column("price_paid")]
    public BigInteger PricePaid { get; set; }
}
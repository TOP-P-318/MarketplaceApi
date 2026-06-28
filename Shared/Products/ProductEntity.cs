using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Shared.Constants;
using Shared.Infrastructure;
using Shared.Users;

namespace Shared.Products;

[Table("products")]
public sealed class ProductEntity : Entity<ProductEntity>
{
    [Required]
    [Column("seller_id")]
    public Guid SellerId { get; set; }
    [ForeignKey(nameof(SellerId))] public UserEntity? Seller { get; set; }

    [Required]
    [Column("name")]
    [MaxLength(Limits.Product.Name.MaxLength)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [Column("description")]
    public string? Description { get; set; }
    [Required]
    [Column("image_urls")]
    public string[] ImageUrls { get; set; } = [];
    [Required]
    [Column("price")]
    public BigInteger Price { get; set; }
    [Required]
    [Column("amount")]
    public int Amount { get; set; }
    [Required]
    [Column("characteristics", TypeName = "jsonb")]
    public Dictionary<string, string> Characteristics { get; set; } = new();


    public override void Update(ProductEntity other)
    {
        base.Update(other);
        SellerId = other.SellerId;
        Name = other.Name;
        ImageUrls = other.ImageUrls;
        Price = other.Price;
        Amount = other.Amount;
        Description = other.Description;
        Characteristics = other.Characteristics;
    }
}
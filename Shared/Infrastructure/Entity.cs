using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Infrastructure;

public abstract class Entity
{
    [Required]
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    [Required]
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}

public abstract class Entity<TSelf> : Entity where TSelf : Entity<TSelf>
{
    public virtual void Update(TSelf other)
    {
        UpdatedAt = other.UpdatedAt;
    }
}
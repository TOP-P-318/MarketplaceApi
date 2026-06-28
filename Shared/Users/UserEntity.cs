using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Shared.Constants;
using Shared.Enums;
using Shared.Infrastructure;

namespace Shared.Users;

[Table("users")]
public class UserEntity : Entity<UserEntity>
{
    [Required]
    [Column("name")]
    [MaxLength(Limits.User.Name.MaxLength)]
    public string Name { get; set; } = string.Empty;

    [Required] [Column("phone")] public string Phone { get; set; } = string.Empty;

    [Required] [Column("password_hash")] public string PasswordHash { get; set; } = string.Empty;

    [Required] [Column("balance")] public BigInteger Balance { get; set; }

    [Required]
    [Column("role", TypeName = "text")]
    public UserRoles Role { get; set; }

    public override void Update(UserEntity other)
    {
        base.Update(other);
        Name = other.Name;
        Phone = other.Phone;
        PasswordHash = other.PasswordHash;
        Balance = other.Balance;
        Role = other.Role;
    }
}
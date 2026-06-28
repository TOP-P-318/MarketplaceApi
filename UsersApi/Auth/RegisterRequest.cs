using System.ComponentModel.DataAnnotations;
using Shared.Constants;

namespace UsersApi.Auth;

public sealed record RegisterRequest
{
    [Required]
    [MaxLength(Limits.User.Name.MaxLength)]
    public required string Name { get; init; }

    [Required]
    [RegularExpression(@"^\+[1-9]\d{1,14}$")]
    public required string Phone { get; init; }

    [Required] public required string Password { get; init; }
}
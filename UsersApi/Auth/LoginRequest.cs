using System.ComponentModel.DataAnnotations;

namespace UsersApi.Auth;

public sealed record LoginRequest
{
    [Required]
    [RegularExpression(@"^\+[1-9]\d{1,14}$")]
    public required string Phone { get; init; }

    [Required] public required string Password { get; init; }
}
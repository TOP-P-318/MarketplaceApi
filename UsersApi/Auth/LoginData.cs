using Shared.Enums;

namespace UsersApi.Auth;

public sealed record LoginData
{
    public required Guid Id { get; init; }
    public required UserRoles Role { get; init; }
}
using System.Numerics;
using Shared.Enums;
using Shared.Infrastructure;

namespace Shared.Users;

public sealed record UserModel : Model
{
    public string Name { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public string PasswordHash { get; init; } = string.Empty;
    public BigInteger Balance { get; init; }
    public UserRoles Role { get; init; }

    public UserModel WithIncBalance(BigInteger inc) =>
        Touch<UserModel>() with
        {
            Balance = Balance + inc
        };

    public UserModel WithDecBalance(BigInteger dec) =>
        Touch<UserModel>() with
        {
            Balance = Balance - dec
        };

    public UserModel WithPasswordHash(string passwordHash) =>
        this with
        {
            PasswordHash = passwordHash
        };
}
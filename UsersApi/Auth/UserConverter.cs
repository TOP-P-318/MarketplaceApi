using Shared.Users;

namespace UsersApi.Auth;

public static class UserConverter
{
    public static LoginData ConvertToLoginClaims(this UserModel user) => new()
    {
        Id = user.Id,
        Role = user.Role,
    };
}
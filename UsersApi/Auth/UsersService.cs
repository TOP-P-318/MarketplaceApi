using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Shared.Enums;
using Shared.Users;

namespace UsersApi.Auth;

public sealed class UsersService(UsersRepo usersRepo, PasswordHasher<UserModel> passwordHasher)
{
    public async Task CreateUserAsync(RegisterRequest request, UserRoles role)
    {
        var other = await usersRepo.FindByPhoneAsync(request.Phone);
        if  (other != null) throw new InvalidOperationException($"Phone number {request.Phone} is already registered");
        
        var user = new UserModel
        {
            Name = request.Name,
            Phone = request.Phone,
            Role = role,
            Balance = 0,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        var passwordHash = passwordHasher.HashPassword(user, request.Password);
        user = user.WithPasswordHash(passwordHash);
        await usersRepo.AddAsync(user);
    }

    public async Task<LoginData?> ValidateCredentialsAsync(LoginRequest request)
    {
        var user = await usersRepo.FindByPhoneAsync(request.Phone);
        if (user == null) return null;
        var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
        return verificationResult == PasswordVerificationResult.Failed ? null : user.ConvertToLoginClaims();
    }

    public ClaimsPrincipal CreateClaimsPrincipal(LoginData data)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, data.Id.ToString()),
            new(ClaimTypes.Role, data.Role.ToString()),
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        return new ClaimsPrincipal(identity);
    }
}
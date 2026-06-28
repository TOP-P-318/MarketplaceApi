using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Enums;

namespace UsersApi.Auth;

[ApiController]
[Route("api/users")]
public sealed class UsersController(UsersService usersService) : ControllerBase
{
    [HttpPost("register/buyer")]
    public async Task<ActionResult> RegisterAsBuyerAsync(RegisterRequest request)
    {
        await usersService.CreateUserAsync(request, UserRoles.Buyer);
        return NoContent();
    }

    [HttpPost("login")]
    public async Task<ActionResult> LoginAsync([FromBody] LoginRequest request)
    {
        var loginData = await usersService.ValidateCredentialsAsync(request);
        if (loginData == null) return Forbid();
        var principal = usersService.CreateClaimsPrincipal(loginData);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        return NoContent();
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<ActionResult> LogoutAsync()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return NoContent();
    }
}
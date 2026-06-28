using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurchaseApi.Constants;
using PurchaseApi.Purchase.Requests;
using Shared.Constants;

namespace PurchaseApi.Purchase;

[ApiController]
[Authorize]
[Route("api/purchases")]
public sealed class PurchaseController(PurchaseService purchaseService) : ControllerBase
{
    [HttpPost(Name = Routes.Purchase.Create)]
    [Authorize(Roles = UserRole.Buyer)]
    public async Task<ActionResult> CreateAsync([FromBody] CreatePurchaseRequest request)
    {
        if (!Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var buyerId))
            return Unauthorized();

        var purchaseId = await purchaseService.CreatePurchaseAsync(request, buyerId);

        return CreatedAtRoute(Routes.Purchase.Get, new { id = purchaseId }, purchaseId);
    }

    [HttpGet("{id:guid}", Name = Routes.Purchase.Get)]
    public async Task<ActionResult> GetAsync([FromRoute] Guid id)
    {
        var response = await purchaseService.GetPurchaseAsync(id);
        if (response == null) return NotFound();
        return Ok(response);
    }

    [HttpGet("debug")]
    [AllowAnonymous]
    public ActionResult Debug() => Ok(new
    {
        User.Identity?.IsAuthenticated,
        UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
        Role = User.FindFirstValue(ClaimTypes.Role),
        Claims = User.Claims.Select(c => new { c.Type, c.Value })
    });
}
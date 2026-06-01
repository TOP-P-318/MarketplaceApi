using Microsoft.AspNetCore.Mvc;

namespace GoodsApi.Controllers;

[ApiController]
[Route("api")]
public class TestController : ControllerBase
{
    [HttpGet("hello")]
    public async Task<ActionResult<string>> Get()
    {
        return "Hello World!";
    }
}
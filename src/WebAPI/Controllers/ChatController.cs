using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ChatController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    // private readonly IChatFacade _chatFacade;

    public ChatController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    [HttpPost("new")]
    public async Task<ActionResult<string>> New([FromQuery] string username)
    {
        if (_httpContextAccessor.HttpContext == null) return Forbid();
        var jwtUsername = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        return Ok();
    }
}
using System.Security.Claims;
using BusinessLayer.Facades.FacadeInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FriendshipController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IFriendshipFacade _friendshipFacade;
    public FriendshipController(IHttpContextAccessor httpContextAccessor, IFriendshipFacade friendshipFacade)
    {
        _httpContextAccessor = httpContextAccessor;
        _friendshipFacade = friendshipFacade;
    }

    [HttpPost("addFriend")]
    public async Task<ActionResult<string>> AddFriend([FromQuery(Name = "user")] string usernameToBeFriend)
    {
        if (_httpContextAccessor.HttpContext == null) return Forbid();
        var jwtUsername = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        await _friendshipFacade.AddFriend(jwtUsername, usernameToBeFriend);
        return Ok();
    }

    [HttpDelete("removeFriend")]
    public async Task<ActionResult> RemoveFriend([FromQuery(Name = "user")] string username)
    {
        if (_httpContextAccessor.HttpContext == null) return Forbid();
        var jwtUsername = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        await _friendshipFacade.RemoveFriend(jwtUsername, username);
        return Ok();
    }
}
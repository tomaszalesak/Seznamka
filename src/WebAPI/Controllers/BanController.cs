using System.Security.Claims;
using BusinessLayer.DataTransferObjects;
using BusinessLayer.Facades.FacadeInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BanController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IBanFacade _banFacade;
    private readonly IFriendshipFacade _friendshipFacade;

    public BanController(IHttpContextAccessor httpContextAccessor, IBanFacade banFacade, IFriendshipFacade friendshipFacade)
    {
        _httpContextAccessor = httpContextAccessor;
        _banFacade = banFacade;
        _friendshipFacade = friendshipFacade;
    }

    [HttpPost]
    public async Task<ActionResult<string>> Ban([FromQuery(Name = "userToBan")] string usernameToBan)
    {
        if (_httpContextAccessor.HttpContext == null) return Forbid();
        var jwtUsername = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        await _banFacade.Ban(jwtUsername, usernameToBan);
        await _friendshipFacade.RemoveFriend(jwtUsername, usernameToBan);
        return Ok();
    }
    
    [HttpGet("banned")]
    public ActionResult<IList<UserDto>> BannedUsers()
    {
        if (_httpContextAccessor.HttpContext == null) return Forbid();
        var jwtUsername = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        return Ok(_banFacade.BannedUsers(jwtUsername));
    }
    
    [HttpDelete("removeBan")]
    public async Task<ActionResult> RemoveBan([FromQuery] int id)
    {
        if (_httpContextAccessor.HttpContext == null) return Forbid();
        var jwtUsername = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        await _banFacade.RemoveBan(jwtUsername, id);
        return Ok();
    }
}
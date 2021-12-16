using System.Security.Claims;
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

    public BanController(IHttpContextAccessor httpContextAccessor, IBanFacade banFacade)
    {
        _httpContextAccessor = httpContextAccessor;
        _banFacade = banFacade;
    }

    [HttpPost]
    public async Task<ActionResult<string>> Ban([FromQuery(Name = "userToBan")] string usernameToBan)
    {
        if (_httpContextAccessor.HttpContext == null) return Forbid();
        var jwtUsername = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        await _banFacade.Ban(jwtUsername, usernameToBan);
        return Ok();
    }
}
using BusinessLayer.DataTransferObjects;
using BusinessLayer.Facades.FacadeInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserFacade _userFacade;

    public UserController(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }

    [HttpPost]
    public async Task<ActionResult> Register([FromBody] UserRegistrationDto user)
    {
        await _userFacade.RegisterAsync(user);
        return Ok();
    }
}
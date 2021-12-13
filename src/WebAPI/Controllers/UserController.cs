using System.Security.Claims;
using BusinessLayer.DataTransferObjects;
using BusinessLayer.Facades.FacadeInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserFacade _userFacade;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserController(IUserFacade userFacade, IHttpContextAccessor httpContextAccessor)
    {
        _userFacade = userFacade;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult> Register([FromForm] UserRegistrationModel user)
    {
        var userDto = new UserRegistrationDto
        {
            Name = user.Name,
            Surname = user.Surname,
            Username = user.Username,
            Password = user.Password,
            Birthdate = user.Birthdate,
            Gender = user.Gender,
            Height = user.Height,
            Weight = user.Weight,
            Bio = user.Bio,
            Longitude = user.Longitude,
            Latitude = user.Latitude,
            Preferences = new PreferencesDto
            {
                MinAge = user.PreferencesDto.MinAge,
                MaxAge = user.PreferencesDto.MaxAge,
                MinWeight = user.PreferencesDto.MinWeight,
                MaxWeight = user.PreferencesDto.MaxWeight,
                MinHeight = user.PreferencesDto.MinHeight,
                MaxHeight = user.PreferencesDto.MaxHeight,
                GpsRadius = user.PreferencesDto.GpsRadius
            }
        };

        var form = Request.Form;
        
        if (!form.Any()) return Ok(await _userFacade.RegisterAsync(userDto));
        
        await using var stream = new MemoryStream();
        await form.Files[0].CopyToAsync(stream);
        userDto.Photo = stream.ToArray();

        return Ok(await _userFacade.RegisterAsync(userDto));
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<UserDto>> GetProfileByUsername(string username)
    {
        return Ok();
    }
    
    [HttpPut]
    public async Task<ActionResult<UserDto>> ChangeProfileByUsername(UserDto userDto)
    {
        
        return Ok();
    }
}
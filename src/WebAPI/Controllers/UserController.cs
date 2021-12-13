using System.Security.Claims;
using BusinessLayer.DataTransferObjects;
using BusinessLayer.Facades.FacadeInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserFacade _userFacade;

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

    [HttpGet("find")]
    public ActionResult<UserDto> GetAllPossiblePartners([FromQuery(Name = "age")] bool age,
        [FromQuery(Name = "height")] bool height, [FromQuery(Name = "weight")] bool weight)
    {
        if (_httpContextAccessor.HttpContext == null) return BadRequest();
        var jwtUsername = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        var possiblePartners = _userFacade.GetAllPossiblePartners(jwtUsername);
        return Ok(possiblePartners);
    }
}
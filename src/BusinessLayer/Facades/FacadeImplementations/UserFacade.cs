using BusinessLayer.DataTransferObjects;
using BusinessLayer.Facades.FacadeInterfaces;
using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utils;
using Infrastructure.Persistence.UnitOfWork;

namespace BusinessLayer.Facades.FacadeImplementations;

public class UserFacade : FacadeBase, IUserFacade
{
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;

    public UserFacade(IUnitOfWorkProvider provider, IUserService userService, ITokenService tokenService) :
        base(provider)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    public async Task<string> RegisterAsync(UserRegistrationDto userRegistrationDto)
    {
        if (userRegistrationDto == null) throw new ArgumentException("User data can't be null.");

        using (var uow = UnitOfWorkProvider.Create())
        {
            if (_userService.UsernameAlreadyExists(userRegistrationDto.Username))
                throw new ArgumentException("Username already exists.");

            await _userService.CreateAsync(new UserDto
            {
                Name = userRegistrationDto.Name,
                Surname = userRegistrationDto.Surname,
                Username = userRegistrationDto.Username,
                PasswordHash = Hashing.Encode(userRegistrationDto.Password),
                Birthdate = userRegistrationDto.Birthdate,
                Gender = userRegistrationDto.Gender,
                Height = userRegistrationDto.Height,
                Weight = userRegistrationDto.Weight,
                Bio = userRegistrationDto.Bio,
                Longitude = userRegistrationDto.Longitude,
                Latitude = userRegistrationDto.Latitude,
                Preferences = userRegistrationDto.Preferences
            });

            await uow.CommitAsync();
        }

        var token = _tokenService.BuildToken("PUT_YOUR_JWT_SECRET_HERE", "Seznamka", userRegistrationDto.Username);

        return token;
    }

    public IList<UserDto> GetAllPossiblePartners(string username)
    {
        var user = _userService.GetUserByUsername(username);
        
        return _userService.GetAllUsers().ToList();
    }
}
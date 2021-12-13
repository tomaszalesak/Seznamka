using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
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

    public async Task<string> LoginAsync(UserLoginDto userLoginDto)
    {
        if (userLoginDto == null) throw new ArgumentException("User login data can't be null.");
        if (userLoginDto.Password == null) throw new ArgumentException("User password can't be null.");
        if (userLoginDto.UserName == null) throw new ArgumentException("User name can't be null.");

        var user = _userService.GetUserByUsername(userLoginDto.UserName);
        if (user == null) throw new Exception("User does not exist.");

        if (Hashing.Validate(userLoginDto.Password, user.PasswordHash))
            return _tokenService.BuildToken("PUT_YOUR_JWT_SECRET_HERE", "Seznamka", user.Username);

        throw new ArgumentException("Wrong password.");
    }

    public IList<UserDto> GetAllPossiblePartners(string usernameToOmit, int requestedPage,
        bool filterByAge, bool filterByHeight, bool filterByWeight, int pageSize)
    {
        using (UnitOfWorkProvider.Create())
        {
            var user = _userService.GetUserByUsername(usernameToOmit);
            return _userService.GetAllUsers(usernameToOmit, filterByAge
                ? new UserAgeFilterDto
                {
                    MinAge = user.Preferences.MinAge,
                    MaxAge = user.Preferences.MaxAge
                }
                : null, filterByWeight
                ? new UserWeightDto
                {
                    MinWeight = user.Preferences.MinWeight,
                    MaxWeight = user.Preferences.MaxWeight
                }
                : null, filterByHeight
                ? new UserHeightFilterDto
                {
                    MinHeight = user.Preferences.MinHeight,
                    MaxHeight = user.Preferences.MaxHeight
                }
                : null, pageSize, requestedPage).ToList();
        }
    }
}
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
    private readonly IUserPhotoService _userPhotoService;

    public UserFacade(IUnitOfWorkProvider provider, IUserService userService, ITokenService tokenService, IUserPhotoService userPhotoService) :
        base(provider)
    {
        _userService = userService;
        _tokenService = tokenService;
        _userPhotoService = userPhotoService;
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
                Preferences = userRegistrationDto.Preferences,
                Photos = new List<UserPhotoDto>
                {
                    new()
                    {
                        Image = userRegistrationDto.Photo
                    }
                }
            });

            await uow.CommitAsync();
        }

        var token = _tokenService.BuildToken("PUT_YOUR_JWT_SECRET_HERE", "Seznamka", userRegistrationDto.Username);

        return token;
    }

    public string LoginAsync(UserLoginDto userLoginDto)
    {
        if (userLoginDto == null) throw new ArgumentException("User login data can't be null.");
        if (userLoginDto.Password == null) throw new ArgumentException("User password can't be null.");
        if (userLoginDto.UserName == null) throw new ArgumentException("User name can't be null.");

        using (UnitOfWorkProvider.Create())
        {
            var user = _userService.GetUserByUsername(userLoginDto.UserName);
            if (user == null) throw new Exception("User does not exist.");

            if (Hashing.Validate(userLoginDto.Password, user.PasswordHash))
                return _tokenService.BuildToken("PUT_YOUR_JWT_SECRET_HERE", "Seznamka", user.Username);
        }

        throw new ArgumentException("Wrong password.");
    }

    public UsersFoundDto GetAllPossiblePartners(string usernameToOmit, int requestedPage,
        bool filterByAge, bool filterByHeight, bool filterByWeight, int pageSize)
    {
        using (UnitOfWorkProvider.Create())
        {
            var user = _userService.GetUserByUsername(usernameToOmit);
            return _userService.GetAllPossibleUsers(usernameToOmit, filterByAge
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
                : null, pageSize, requestedPage);
        }
    }

    public UserPhotoDto GetProfilePhoto(string username)
    {
        using (UnitOfWorkProvider.Create())
        {
            return _userPhotoService.GetProfilePhoto(username);
        }
    }

    public IList<UserDto> GetReceivedBans(string username)
    {
        using (UnitOfWorkProvider.Create())
        {
            return _userService.GetReceivedBans(username);
        }
    }

    public IList<UserDto> GetBannedUsers(string username)
    {
        using (UnitOfWorkProvider.Create())
        {
            return _userService.GetBannedUsers(username);
        }
    }
}
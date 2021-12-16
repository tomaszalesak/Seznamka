using BusinessLayer.DataTransferObjects;

namespace BusinessLayer.Facades.FacadeInterfaces;

public interface IUserFacade : IDisposable
{
    Task<string> RegisterAsync(UserRegistrationDto userRegistrationDto);
    
    string LoginAsync(UserLoginDto userLoginDto);

    UsersFoundDto GetAllPossiblePartners(string usernameToOmit, int requestedPage,
        bool filterByAge, bool filterByHeight, bool filterByWeight, int pageSize);

    UserPhotoDto GetProfilePhoto(string username);
    IList<UserDto> GetReceivedBans(string username);
    IList<UserDto> GetBannedUsers(string username);
}
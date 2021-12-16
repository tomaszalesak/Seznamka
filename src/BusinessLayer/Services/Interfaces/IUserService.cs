using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;

namespace BusinessLayer.Services.Interfaces
{
    public interface IUserService : ICrudQueryServiceBase<UserDto>
    {
        IList<UserDto> GetReceivedBans(string username);
        IList<UserDto> GetBannedUsers(string username);
        public UserDto GetUserByUsername(string username);
        public bool UsernameAlreadyExists(string username);
        Task<string> GetUsernameAsync(int userId);
        UsersFoundDto GetAllUsers(string userToOmit, UserAgeFilterDto age, UserWeightDto weight, UserHeightFilterDto height, int pageSize, int requestedPage);
    }
}
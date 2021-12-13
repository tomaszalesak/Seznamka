using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;

namespace BusinessLayer.Services.Interfaces
{
    public interface IUserService : ICrudQueryServiceBase<UserDto>
    {
        public UserDto GetUserByUsername(string username);
        public bool UsernameAlreadyExists(string username);
        Task<string> GetUsernameAsync(int userId);
        IEnumerable<UserDto> GetAllUsers(string userToOmit, UserAgeFilterDto age, UserWeightDto weight, UserHeightFilterDto height, int pageSize, int requestedPage);
    }
}
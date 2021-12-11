using BusinessLayer.DataTransferObjects;

namespace BusinessLayer.Services.Interfaces
{
    public interface IUserService : ICrudQueryServiceBase<UserDto>
    {
        public UserDto GetUserByUsername(string username);
        public bool UsernameAlreadyExists(string username);
        Task<string> GetUsernameAsync(int userId);
        IEnumerable<UserDto> GetAllUsers();
    }
}
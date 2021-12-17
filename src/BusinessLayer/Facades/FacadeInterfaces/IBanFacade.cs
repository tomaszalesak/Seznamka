using BusinessLayer.DataTransferObjects;

namespace BusinessLayer.Facades.FacadeInterfaces;

public interface IBanFacade : IDisposable
{
    Task Ban(string banningUser, string userToBeBanned);
    IList<BanWithUsersDto> BannedUsers(string jwtUsername);
    Task RemoveBan(string jwtUsername, int id);
}
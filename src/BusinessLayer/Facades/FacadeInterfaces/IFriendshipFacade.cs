namespace BusinessLayer.Facades.FacadeInterfaces;

public interface IFriendshipFacade : IDisposable
{
    Task AddFriend(string jwtUsername, string usernameToBeFriend);
    Task RemoveFriend(string jwtUsername, string username);
}
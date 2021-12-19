using BusinessLayer.DataTransferObjects;
using BusinessLayer.Facades.FacadeInterfaces;
using BusinessLayer.Services.Interfaces;
using Infrastructure.Persistence.UnitOfWork;

namespace BusinessLayer.Facades.FacadeImplementations;

public class FriendshipFacade : FacadeBase, IFriendshipFacade
{
    private readonly IChatService _chatService;
    private readonly IFriendshipService _friendshipService;
    private readonly IUserChatService _userChatService;
    private readonly IUserService _userService;
    private readonly IUserService _userService2;

    public FriendshipFacade(IUnitOfWorkProvider provider,
        IFriendshipService friendshipService, IUserService userService, IUserService userService2,
        IChatService chatService, IUserChatService userChatService) : base(provider)
    {
        _friendshipService = friendshipService;
        _userService = userService;
        _userService2 = userService2;
        _chatService = chatService;
        _userChatService = userChatService;
    }

    public async Task AddFriend(string jwtUsername, string usernameToBeFriend)
    {
        using var uow = UnitOfWorkProvider.Create();
        var user = _userService.GetUserByUsername(jwtUsername);
        var user2 = _userService2.GetUserByUsername(usernameToBeFriend);
        await _friendshipService.CreateAsync(new FriendshipDto
        {
            UserId = user.Id,
            FriendId = user2.Id
        });
        await _friendshipService.CreateAsync(new FriendshipDto
        {
            UserId = user2.Id,
            FriendId = user.Id
        });

        var chat = new ChatDto
        {
            Name = user.Name + " " + user2.Name,
            Users = new List<UserChatDto>()
        };

        chat.Users.Add(new UserChatDto
        {
            UserId = user.Id
        });

        chat.Users.Add(new UserChatDto
        {
            UserId = user2.Id
        });

        await _chatService.CreateAsync(chat);
        await uow.CommitAsync();
    }

    public async Task RemoveFriend(string jwtUsername, string username)
    {
        using var uow = UnitOfWorkProvider.Create();
        var user = _userService.GetUserByUsername(jwtUsername);
        var user2 = _userService2.GetUserByUsername(username);
        var friends1 = await _friendshipService.GetAsync(user2.Id, user.Id);
        var friends2 = await _friendshipService.GetAsync(user.Id, user2.Id);
        // if (friends1 is null && friends2 is null) throw new Exception("You have 0 friends :(");
        if (friends1 is not null) await _friendshipService.DeleteAsync(user2.Id, user.Id);
        if (friends2 is not null) await _friendshipService.DeleteAsync(user.Id, user2.Id);
        await uow.CommitAsync();
    }
}
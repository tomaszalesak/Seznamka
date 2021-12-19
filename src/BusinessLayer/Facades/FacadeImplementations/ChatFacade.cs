using BusinessLayer.DataTransferObjects;
using BusinessLayer.Facades.FacadeInterfaces;
using BusinessLayer.Services.Interfaces;
using Infrastructure.Persistence.UnitOfWork;

namespace BusinessLayer.Facades.FacadeImplementations;

public class ChatFacade : FacadeBase, IChatFacade
{
    private readonly IUserChatService _userChatService;
    private readonly IChatService _chatService;
    private readonly IUserService _userService;
    
    public ChatFacade(IUnitOfWorkProvider provider, IChatService chatService, IUserService userService, IUserChatService userChatService) : base(provider)
    {
        _chatService = chatService;
        _userService = userService;
        _userChatService = userChatService;
    }

    public IList<ChatUserNameDto> GetMyChats(string jwtUsername)
    {
        using var uow = UnitOfWorkProvider.Create();
        var user = _userService.GetUserByUsername(jwtUsername);
        return _userChatService.GetUserChats(user.Id);
    }

    public async Task<IList<MessageDto>> GetChatByIdAsync(int chatId)
    {
        var m = await _chatService.GetAsync(chatId);
        return m.Messages;
    }
}
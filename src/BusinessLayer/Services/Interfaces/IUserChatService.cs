using BusinessLayer.DataTransferObjects;

namespace BusinessLayer.Services.Interfaces;

public interface IUserChatService : ICrudQueryServiceBase<UserChatDto>
{
    IList<ChatUserNameDto> GetUserChats(int userId);
}
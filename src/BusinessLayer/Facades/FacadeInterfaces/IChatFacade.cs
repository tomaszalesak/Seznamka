using BusinessLayer.DataTransferObjects;

namespace BusinessLayer.Facades.FacadeInterfaces;

public interface IChatFacade : IDisposable
{
    IList<ChatUserNameDto> GetMyChats(string jwtUsername);
    Task<IList<MessageDto>> GetChatByIdAsync(int chatId);
}
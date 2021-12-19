using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using BusinessLayer.QueryObjects;
using BusinessLayer.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.Services.Implementations;

public class UserChatService : CrudQueryServiceBase<UserChat, UserChatDto, UserChatFilterDto>, IUserChatService
{
    public UserChatService(IRepository<UserChat> repository, QueryObjectBase<UserChat, UserChatDto, UserChatFilterDto, IQuery<UserChat>> qob) : base(repository, qob)
    {
    }

    public IList<ChatUserNameDto> GetUserChats(int userId)
    {
        var userChats = QueryObject.ExecuteQuery(new UserChatFilterDto { UserId = userId }).Items;
        return userChats.Select(userChat => new ChatUserNameDto
        {
            Id = userChat.ChatId,
            Name = userChat.Chat.Name,
            Users = new List<UserNamesDto>
            {
                new()
                {
                    Name = userChat.Chat.Users[0].User.Name,
                    Surname = userChat.Chat.Users[0].User.Surname,
                    Username = userChat.Chat.Users[0].User.Username,
                    Photos = userChat.Chat.Users[0].User.Photos
                },
                new()
                {
                    Name = userChat.Chat.Users[1].User.Name,
                    Surname = userChat.Chat.Users[1].User.Surname,
                    Username = userChat.Chat.Users[1].User.Username,
                    Photos = userChat.Chat.Users[1].User.Photos
                },
            },
            Messages = userChat.Chat.Messages
        }).ToList();
    }
}
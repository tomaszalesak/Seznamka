using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using Domain.Entities;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.QueryObjects;

public class UserChatQueryObject : QueryObjectBase<UserChat, UserChatDto, UserChatFilterDto, IQuery<UserChat>>
{
    public UserChatQueryObject(IQuery<UserChat> query) : base(query)
    {
    }
}
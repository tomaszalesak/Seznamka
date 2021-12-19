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
    
    public override IQuery<UserChat> ApplyFilter(IQuery<UserChat> query, UserChatFilterDto
        filter)
    {
        query = filter.UserId == null
            ? query
            : ((UserChatQuery)query)?.FilterByUserId(filter.UserId.Value);

        return query;
    }
}
using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using Domain.Entities;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.QueryObjects;

public class FriendshipQueryObject : QueryObjectBase<Friendship, FriendshipDto, FriendshipFilterDto, IQuery<Friendship>>
{
    public FriendshipQueryObject(IQuery<Friendship> query) : base(query)
    {
    }
}
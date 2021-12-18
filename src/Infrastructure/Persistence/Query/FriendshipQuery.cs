using Domain.Entities;
using Infrastructure.Persistence.UnitOfWork;

namespace Infrastructure.Persistence.Query;

public class FriendshipQuery : QueryBase<Friendship>
{
    public FriendshipQuery(IUnitOfWorkProvider provider) : base(provider)
    {
    }
}
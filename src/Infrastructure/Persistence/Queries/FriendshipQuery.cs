using Domain.Entities;
using Domain.Interfaces.Queries;

namespace Infrastructure.Persistence.Queries
{
    public class FriendshipQuery : GenericQuery<Friendship>, IFriendshipQuery
    {
        public FriendshipQuery(SeznamkaDbContext context) : base(context)
        {

        }
    }
}
using Domain.Entities;
using Domain.Interfaces.QueryInterfaces;

namespace EFInfrastructure.Queries
{
    public class FriendshipQuery : GenericQuery<Friendship>, IFriendshipQuery
    {
        public FriendshipQuery(SeznamkaDbContext _context) : base(_context)
        {

        }
    }
}

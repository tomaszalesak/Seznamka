using Domain.Entities;
using Domain.Interfaces.Queries;

namespace Infrastructure.Persistence.Queries
{
    public class ChatQuery: GenericQuery<Chat>, IChatQuery
    {
        public ChatQuery(SeznamkaDbContext context) : base(context)
        {

        }
    }
}
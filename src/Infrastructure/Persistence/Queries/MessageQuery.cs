using Domain.Entities;
using Domain.Interfaces.Queries;

namespace Infrastructure.Persistence.Queries
{
    public class MessageQuery : GenericQuery<Message>, IMessageQuery
    {
        public MessageQuery(SeznamkaDbContext context) : base(context)
        {

        }
    }
}
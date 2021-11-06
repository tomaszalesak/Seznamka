using Domain.Entities;
using Domain.Interfaces.QueryInterfaces;

namespace EFInfrastructure.Queries
{
    public class MessageQuery : GenericQuery<Message>, IMessageQuery
    {
        public MessageQuery(SeznamkaDbContext _context) : base(_context)
        {

        }
    }
}

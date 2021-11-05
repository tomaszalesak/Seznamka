using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;

namespace EFInfrastructure.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(SeznamkaDbContext context) : base(context)
        {
        }
    }
}
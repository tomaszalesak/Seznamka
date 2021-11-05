using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;

namespace EFInfrastructure.Repositories
{
    public class ChatRepository : GenericRepository<Chat>, IChatRepository
    {
        public ChatRepository(SeznamkaDbContext context) : base(context)
        {
        }
    }
}
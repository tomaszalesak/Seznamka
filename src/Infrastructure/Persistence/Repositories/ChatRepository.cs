using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence.Repositories.Base;

namespace Infrastructure.Persistence.Repositories
{
    public class ChatRepository : GenericRepository<Chat>, IChatRepository
    {
    }
}
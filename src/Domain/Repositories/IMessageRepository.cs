using Domain.Entities;
using Domain.Repositories.Base;

namespace Domain.Repositories
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
    }
}
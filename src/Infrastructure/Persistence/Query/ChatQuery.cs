using Domain.Entities;
using Infrastructure.Persistence.UnitOfWork;

namespace Infrastructure.Persistence.Query;

public class ChatQuery : QueryBase<Chat>

{
    public ChatQuery(IUnitOfWorkProvider provider) : base(provider) { }
}
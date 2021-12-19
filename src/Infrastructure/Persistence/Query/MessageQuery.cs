using Domain.Entities;
using Infrastructure.Persistence.UnitOfWork;

namespace Infrastructure.Persistence.Query;

public class MessageQuery : QueryBase<Message>

{
    public MessageQuery(IUnitOfWorkProvider provider) : base(provider) { }
}
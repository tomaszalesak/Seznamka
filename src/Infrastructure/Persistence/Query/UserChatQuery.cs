using Domain.Entities;
using Infrastructure.Persistence.UnitOfWork;

namespace Infrastructure.Persistence.Query;

public class UserChatQuery : QueryBase<UserChat>

{
    public UserChatQuery(IUnitOfWorkProvider provider) : base(provider) { }
}
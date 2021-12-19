using Domain.Entities;
using Infrastructure.Persistence.UnitOfWork;

namespace Infrastructure.Persistence.Query;

public class UserChatQuery : QueryBase<UserChat>

{
    public UserChatQuery(IUnitOfWorkProvider provider) : base(provider) { }
    
    public UserChatQuery FilterByUserId(int id)
    {
        Queryable = Queryable.Where(chat => chat.UserId == id);
        return this;
    }
}
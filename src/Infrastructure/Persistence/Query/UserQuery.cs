using Domain.Entities;
using Infrastructure.Persistence.UnitOfWork;

namespace Infrastructure.Persistence.Query;

public class UserQuery : QueryBase<User>
{
    public UserQuery(IUnitOfWorkProvider provider) : base(provider)
    {
    }

    public UserQuery FilterByUsername(string username)
    {
        Queryable = Queryable.Where(u => u.Username == username);
        return this;
    }
}
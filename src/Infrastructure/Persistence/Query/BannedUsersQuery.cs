using Domain.Entities;
using Infrastructure.Persistence.UnitOfWork;

namespace Infrastructure.Persistence.Query;

public class BannedUsersQuery : QueryBase<Ban>
{
    public BannedUsersQuery(IUnitOfWorkProvider provider) : base(provider)
    {
    }

    public BannedUsersQuery FilterByBannerId(int id)
    {
        Queryable = Queryable.Where(b => b.BannerId == id);
        return this;
    }
}
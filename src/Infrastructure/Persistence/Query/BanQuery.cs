using Domain.Entities;
using Infrastructure.Persistence.UnitOfWork;

namespace Infrastructure.Persistence.Query;

public class BanQuery : QueryBase<Ban>
{
    public BanQuery(IUnitOfWorkProvider provider) : base(provider)
    {
    }
}
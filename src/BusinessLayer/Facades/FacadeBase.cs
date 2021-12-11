using Infrastructure.Persistence.UnitOfWork;

namespace BusinessLayer.Facades;

public abstract class FacadeBase
{
    protected readonly IUnitOfWorkProvider UnitOfWorkProvider;

    protected FacadeBase(IUnitOfWorkProvider provider)
    {
        UnitOfWorkProvider = provider;
    }

    public void Dispose()
    {
        UnitOfWorkProvider.Dispose();
    }
}
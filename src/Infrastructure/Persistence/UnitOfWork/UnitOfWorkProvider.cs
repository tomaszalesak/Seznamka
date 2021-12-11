namespace Infrastructure.Persistence.UnitOfWork;

public class UnitOfWorkProvider : IUnitOfWorkProvider
{
    private readonly Func<SeznamkaDbContext> _contextFactory;
    private readonly AsyncLocal<IUnitOfWork> _unitOfWorkLocal = new();

    public UnitOfWorkProvider(Func<SeznamkaDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public IUnitOfWork Create()
    {
        _unitOfWorkLocal.Value = new UnitOfWork(_contextFactory.Invoke());
        return _unitOfWorkLocal.Value;
    }

    public void Dispose()
    {
        _unitOfWorkLocal.Value?.Dispose();
        _unitOfWorkLocal.Value = null;
    }

    public IUnitOfWork GetUnitOfWorkInstance()
    {
        return _unitOfWorkLocal.Value ?? throw new InvalidOperationException("Unit of work not created.");
    }
}
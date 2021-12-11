namespace Infrastructure.Persistence.UnitOfWork
{
    public interface IUnitOfWorkProvider : IDisposable
    {
        IUnitOfWork Create();
        IUnitOfWork GetUnitOfWorkInstance();
    }
}
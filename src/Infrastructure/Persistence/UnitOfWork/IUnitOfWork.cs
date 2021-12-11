namespace Infrastructure.Persistence.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    public SeznamkaDbContext Context { get; set; }
    Task CommitAsync();
}
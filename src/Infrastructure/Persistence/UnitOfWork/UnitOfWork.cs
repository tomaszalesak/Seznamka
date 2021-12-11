namespace Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public SeznamkaDbContext
            Context { get; set; }

        public UnitOfWork(SeznamkaDbContext context)
        {
            Context = context;
        }

        public Task CommitAsync()
        {
            return Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
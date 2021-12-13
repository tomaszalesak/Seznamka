namespace Infrastructure.Persistence;

public interface IRepository<TEntity> where TEntity : class, new()
{
    
    Task<TEntity> GetByIdAsync(params object[] keyValues); 
    IQueryable<TEntity> GetAll();
    Task CreateAsync(TEntity entity);
    void Update(TEntity entity);
    Task DeleteAsync(params object[] keyValues);
}
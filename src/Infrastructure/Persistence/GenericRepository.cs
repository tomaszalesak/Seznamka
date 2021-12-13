using Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
{
    private readonly IUnitOfWorkProvider _unitOfWorkProvider;

    public GenericRepository(IUnitOfWorkProvider provider)
    {
        _unitOfWorkProvider = provider;
    }

    public Task<TEntity> GetByIdAsync(params object[] keyValues)
    {
        var context = _unitOfWorkProvider.GetUnitOfWorkInstance().Context;
        return context.Set<TEntity>().FindAsync(keyValues).AsTask();
    }

    public IQueryable<TEntity> GetAll()
    {
        var context = _unitOfWorkProvider.GetUnitOfWorkInstance().Context;
        return context.Set<TEntity>();
    }

    public async Task CreateAsync(TEntity entity)
    {
        var context = _unitOfWorkProvider.GetUnitOfWorkInstance().Context;
        await context.Set<TEntity>().AddAsync(entity);
        context.Entry(entity).State = EntityState.Added;
    }

    public void Update(TEntity entity)
    {
        var context = _unitOfWorkProvider.GetUnitOfWorkInstance().Context;
        context.Entry(entity).State = EntityState.Modified;
        var e = context.Entry(entity);
    }

    public async Task DeleteAsync(params object[] keyValues)
    {
        var context = _unitOfWorkProvider.GetUnitOfWorkInstance().Context;
        var e = await context.Set<TEntity>().FindAsync(keyValues);
        if (e != null)
        {
            context.Set<TEntity>().Remove(e);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SeznamkaDbContext _seznamkaDbContext;
        private readonly DbSet<T> _table;

        public GenericRepository(SeznamkaDbContext seznamkaDbContext)
        {
            _seznamkaDbContext = seznamkaDbContext;
            _table = _seznamkaDbContext.Set<T>();
        }

        public GenericRepository()
        {
            _seznamkaDbContext = new SeznamkaDbContext();
            _table = _seznamkaDbContext.Set<T>();
        }
        
        public async Task<T> GetByIdAsync(params object[] keyValues)
        {
            return await _table.FindAsync(keyValues);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }

        public async void SaveAsync()
        {
            await _seznamkaDbContext.SaveChangesAsync();
        }
    }
}
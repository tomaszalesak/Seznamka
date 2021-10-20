using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SeznamkaDbContext _seznamkaDbContext;

        public Repository(SeznamkaDbContext seznamkaDbContext)
        {
            _seznamkaDbContext = seznamkaDbContext;
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            try
            {
                return await _seznamkaDbContext.Set<TEntity>().AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                var item = await _seznamkaDbContext.Set<TEntity>().Where(x => x.Id == id).AsNoTracking()
                    .FirstOrDefaultAsync();
                if (item == null) throw new Exception($"Couldn't find entity with id={id}");

                return item;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity with id={id}: {ex.Message}");
            }
        }

        public async Task<TEntity> CreateAsync(TEntity data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            try
            {
                await _seznamkaDbContext.Set<TEntity>().AddAsync(data);
                await _seznamkaDbContext.SaveChangesAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(data)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            try
            {
                _seznamkaDbContext.Set<TEntity>().Update(data);
                await _seznamkaDbContext.SaveChangesAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(data)} could not be updated: {ex.Message}");
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _seznamkaDbContext.Set<TEntity>().FindAsync(id);
            if (entity == null) throw new Exception($"{nameof(id)} could not be found.");

            _seznamkaDbContext.Set<TEntity>().Remove(entity);
            await _seznamkaDbContext.SaveChangesAsync();
            return true;
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.RepositoryInterfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> GetByIdAsync(params object[] id);
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task AddAsync(TEntity entity);
        public void Delete(TEntity entity);
        public void Update(TEntity entity);
    }
}

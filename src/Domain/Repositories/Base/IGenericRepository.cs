using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories.Base
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(params object[] keyValues);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
        void SaveAsync();
    }
}
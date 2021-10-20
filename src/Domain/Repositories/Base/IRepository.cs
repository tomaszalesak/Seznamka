using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(int id);
    }
}
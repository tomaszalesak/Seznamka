using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.QueryInterfaces
{
    public interface IGenericQuery<TEntity> where TEntity : class
    {
        IGenericQuery<TEntity> Where(Expression<Func<TEntity, bool>> criteria);
        IGenericQuery<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> keySelector, bool isAscendingOrder = true);
        IGenericQuery<TEntity> Page(int pageSize, int pageNumber);
        Task<IEnumerable<TEntity>> ExecuteQueryAsync();
    }
}

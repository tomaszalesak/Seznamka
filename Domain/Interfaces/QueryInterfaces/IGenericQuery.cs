using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.QueryInterfaces
{
    public interface IGenericQuery<TEntity> where TEntity : class
    {
        void OrderBy<TKey>(Expression<Func<TEntity, TKey>> keySelector, bool isAscendingOrder = true);
        void Page(int pageSize, int pageNumber);
        Task<IEnumerable<TEntity>> ExecuteQueryAsync();
    }
}

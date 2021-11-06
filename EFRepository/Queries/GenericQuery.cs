using Domain.Interfaces.QueryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFInfrastructure.Queries
{
    public class GenericQuery<T> : IGenericQuery<T> where T : class
    {
        public IQueryable<T> CurrentResult { get; set; }

        public async Task<IEnumerable<T>> ExecuteQueryAsync()
        {
            return await CurrentResult?.ToListAsync() ?? new List<T>();
        }

        public void OrderBy<TKey>(Expression<Func<T, TKey>> keySelector, bool isAscendingOrder = true)
        {
            if (isAscendingOrder)
            {
                CurrentResult.OrderBy(keySelector);
            }
            else
            {
                CurrentResult.OrderByDescending(keySelector);
            }
        }

        public void Page(int pageSize, int pageNumber)  //pages are numbered from 1
        {
            CurrentResult = CurrentResult.Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);
        }
    }
}

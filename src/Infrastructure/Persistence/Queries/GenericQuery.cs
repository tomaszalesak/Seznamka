using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Interfaces.Queries.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Queries
{
    public class GenericQuery<T> : IGenericQuery<T> where T : class
    {
        protected SeznamkaDbContext _context;
        protected IQueryable<T> CurrentQueryResult;

        protected GenericQuery(SeznamkaDbContext context)
        {
            _context = context;
            CurrentQueryResult = _context.Set<T>();
        }

        protected GenericQuery()
        {
            _context = new SeznamkaDbContext();
            CurrentQueryResult = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> ExecuteQueryAsync()   // todo check query content, consider adding reset to default after exec
        {
            return await CurrentQueryResult?.ToListAsync() ?? new List<T>();
        }

        public IGenericQuery<T> OrderBy<TKey>(Expression<Func<T, TKey>> keySelector, bool isAscendingOrder = true)
        {
            if (isAscendingOrder)
            {
                CurrentQueryResult.OrderBy(keySelector);
            }
            else
            {
                CurrentQueryResult.OrderByDescending(keySelector);
            }

            return this;
        }

        public IGenericQuery<T> Page(int pageSize, int pageNumber)  // pages are numbered from 1
        {
            CurrentQueryResult = CurrentQueryResult.Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);

            return this;
        }
    }
}
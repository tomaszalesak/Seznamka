using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.QueryObjects
{
    public class UserQueryObject : QueryObject
    {
        public UserQueryObject(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<IEnumerable<User>> GetByNameAsync(string userName, bool ascending = true)
        {
            return await UnitOfWork.UserQuery
                .FilterByName(userName)
                .OrderBy(u => u.Id, ascending)
                .ExecuteQueryAsync();
        }
    }
}
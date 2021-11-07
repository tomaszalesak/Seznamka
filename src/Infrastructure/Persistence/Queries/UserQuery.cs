using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Queries;

namespace Infrastructure.Persistence.Queries
{
    public class UserQuery : GenericQuery<User>, IUserQuery
    {
        public UserQuery(SeznamkaDbContext context) : base(context)
        {

        }
        public IUserQuery FilterByName(string name)
        {
            CurrentQueryResult = CurrentQueryResult.Where(user => user.Name == name);
            return this;
        }

        public IUserQuery FilterByNameContains(string name)
        {
            CurrentQueryResult = CurrentQueryResult.Where(user => user.Name != null && user.Name.Contains(name));
            return this;
        }
    }
}
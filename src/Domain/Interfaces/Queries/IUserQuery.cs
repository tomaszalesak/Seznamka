using Domain.Entities;
using Domain.Interfaces.Queries.Base;

namespace Domain.Interfaces.Queries
{
    public interface IUserQuery : IGenericQuery<User>
    {
        public IUserQuery FilterByName(string name);
    }
}
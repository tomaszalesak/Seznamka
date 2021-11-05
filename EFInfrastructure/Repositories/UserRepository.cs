using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;

namespace EFInfrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SeznamkaDbContext context) : base(context)
        {
        }
    }
}
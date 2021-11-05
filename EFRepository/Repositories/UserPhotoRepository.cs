using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;

namespace EFInfrastructure.Repositories
{
    public class UserPhotoRepository : GenericRepository<UserPhoto>, IUserPhotoRepository
    {
        public UserPhotoRepository(SeznamkaDbContext context) : base(context)
        {
        }
    }
}
using Domain.Entities;
using Domain.Interfaces.Queries;

namespace Infrastructure.Persistence.Queries
{
    public class UserPhotoQuery : GenericQuery<UserPhoto>, IUserPhotoQuery
    {
        public UserPhotoQuery(SeznamkaDbContext context) : base(context)
        {

        }
    }
}
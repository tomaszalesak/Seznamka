using Domain.Entities;
using Domain.Interfaces.QueryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInfrastructure.Queries
{
    public class UserPhotoQuery : GenericQuery<UserPhoto>, IUserPhotoQuery
    {
        public UserPhotoQuery(SeznamkaDbContext _context) : base(_context)
        {

        }
    }
}

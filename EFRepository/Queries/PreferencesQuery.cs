using Domain.Entities;
using Domain.Interfaces.QueryInterfaces;

namespace EFInfrastructure.Queries
{
    public class PreferencesQuery : GenericQuery<Preferences>, IPreferencesQuery
    {
        public PreferencesQuery(SeznamkaDbContext _context) : base(_context)
        {

        }
    }
}

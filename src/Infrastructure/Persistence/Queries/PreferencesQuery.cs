using Domain.Entities;
using Domain.Interfaces.Queries;

namespace Infrastructure.Persistence.Queries
{
    public class PreferencesQuery : GenericQuery<Preferences>, IPreferencesQuery
    {
        public PreferencesQuery(SeznamkaDbContext context) : base(context)
        {

        }
    }
}
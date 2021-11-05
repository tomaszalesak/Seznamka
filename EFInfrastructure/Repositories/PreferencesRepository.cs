using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;

namespace EFInfrastructure.Repositories
{
    public class PreferencesRepository : GenericRepository<Preferences>, IPreferencesRepository
    {
        public PreferencesRepository(SeznamkaDbContext context) : base(context)
        {
        }
    }
}
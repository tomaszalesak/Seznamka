using Domain.Entities;
using Infrastructure.Persistence.UnitOfWork;

namespace Infrastructure.Persistence.Query;

public class UserQuery : QueryBase<User>
{
    public UserQuery(IUnitOfWorkProvider provider) : base(provider)
    {
    }

    public UserQuery FilterByUsername(string username)
    {
        Queryable = Queryable.Where(u => u.Username == username);
        return this;
    }

    public UserQuery FilterByAge(int min, int max)
    {
        var now = DateTime.UtcNow;
        var minBirthday = now.AddYears(-min);
        var maxBirthday = now.AddYears(-max);

        Queryable = Queryable.Where(u => u.Birthdate >= minBirthday && u.Birthdate <= maxBirthday);
        return this;
    }
    
    public UserQuery FilterByWeight(int min, int max)
    {
        Queryable = Queryable.Where(u => u.Weight >= min && u.Weight <= max);
        return this;
    }
    
    public UserQuery FilterByHeight(int min, int max)
    {
        Queryable = Queryable.Where(u => u.Height >= min && u.Height <= max);
        return this;
    }
}
using Domain.Entities;
using Infrastructure.Persistence.UnitOfWork;

namespace Infrastructure.Persistence.Query;

public class UserPhotoQuery : QueryBase<UserPhoto>
{
    public UserPhotoQuery(IUnitOfWorkProvider provider) : base(provider)
    {
    }

    public UserPhotoQuery FilterByUsername(string username)
    {
        Queryable = Queryable.Where(u => u.User.Username == username);
        return this;
    }
}
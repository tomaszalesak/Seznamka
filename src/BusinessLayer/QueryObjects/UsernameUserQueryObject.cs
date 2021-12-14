using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using Domain.Entities;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.QueryObjects;

public class UsernameUserQueryObject : QueryObjectBase<User, UserDto, UsernameUserFilterDto, IQuery<User>>
{
    public UsernameUserQueryObject(IQuery<User> query) : base(query)
    {
    }

    public override IQuery<User> ApplyFilter(IQuery<User> query, UsernameUserFilterDto filter)
    {
        query = string.IsNullOrWhiteSpace(filter.Username)
            ? query
            : ((UserQuery)query)?.FilterByUsername(filter.Username);

        return query;
    }
}
using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using Domain.Entities;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.QueryObjects;

public class FindUserQueryObject : QueryObjectBase<User, UserDto, FindUserFilterDto, IQuery<User>>
{
    public FindUserQueryObject(IQuery<User> query) : base(query)
    {
    }

    public override IQuery<User> ApplyFilter(IQuery<User> query, FindUserFilterDto filter)
    {
        if (filter.Age != null) query = ((UserQuery)query)?.FilterByAge(filter.Age.MinAge, filter.Age.MaxAge);
        
        if (filter.Height != null)
            query = ((UserQuery)query)?.FilterByHeight(filter.Height.MinHeight, filter.Height.MaxHeight);
        
        if (filter.Weight != null)
            query = ((UserQuery)query)?.FilterByWeight(filter.Weight.MinWeight, filter.Weight.MaxWeight);
        
        query = string.IsNullOrWhiteSpace(filter.OmitUserByUsername)
            ? query
            : ((UserQuery)query)?.FilterOmitByUsername(filter.OmitUserByUsername);

        return query;
    }
}
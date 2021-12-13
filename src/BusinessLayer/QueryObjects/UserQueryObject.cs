using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using Domain.Entities;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.QueryObjects
{
    public class UserQueryObject : QueryObjectBase<User, UserDto, UserFilterDto, IQuery<User>>
    {
        public UserQueryObject(IQuery<User> query) : base(query) { }

        public override IQuery<User> ApplyFilter(IQuery<User> query, UserFilterDto filter)
        {
            query = string.IsNullOrWhiteSpace(filter.Username) 
                ? query 
                : ((UserQuery) query)?.FilterByUsername(filter.Username);

            query = ((UserQuery) query)?.FilterByAge(filter.Preferences.MinAge, filter.Preferences.MaxAge);
            
            query = ((UserQuery) query)?.FilterByHeight(filter.Preferences.MinHeight, filter.Preferences.MaxHeight);
            
            query = ((UserQuery) query)?.FilterByWeight(filter.Preferences.MinWeight, filter.Preferences.MaxWeight);

            return query;
        }
    }
}
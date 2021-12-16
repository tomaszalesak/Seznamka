using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using Domain.Entities;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.QueryObjects;

public class BannedUsersQueryObject : QueryObjectBase<Ban, BanWithUsersDto, BannedUsersFilterDto, IQuery<Ban>>
{
    public BannedUsersQueryObject(IQuery<Ban> query) : base(query)
    {
    }
    
    public override IQuery<Ban> ApplyFilter(IQuery<Ban> query, BannedUsersFilterDto filter)
    {
        query = filter.BannerId == null
            ? query
            : ((BannedUsersQuery)query)?.FilterByBannerId(filter.BannerId.Value);

        return query;
    }
}
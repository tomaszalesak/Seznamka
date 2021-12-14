using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using Domain.Entities;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.QueryObjects;

public class UserPhotoQueryObject : QueryObjectBase<UserPhoto, UserPhotoDto, UserPhotoFilterDto, IQuery<UserPhoto>>
{
    public UserPhotoQueryObject(IQuery<UserPhoto> query) : base(query)
    {
    }

    public override IQuery<UserPhoto> ApplyFilter(IQuery<UserPhoto> query, UserPhotoFilterDto filter)
    {
        query = string.IsNullOrWhiteSpace(filter.Username)
            ? query
            : ((UserPhotoQuery)query)?.FilterByUsername(filter.Username);

        return query;
    }
}
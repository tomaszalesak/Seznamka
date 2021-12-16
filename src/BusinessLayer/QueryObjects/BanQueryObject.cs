using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using Domain.Entities;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.QueryObjects;

public class BanQueryObject : QueryObjectBase<Ban, BanDto, BanFilterDto, IQuery<Ban>>
{
    public BanQueryObject(IQuery<Ban> query) : base(query)
    {
    }
}
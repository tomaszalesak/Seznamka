using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using BusinessLayer.QueryObjects;
using BusinessLayer.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.Services.Implementations;

public class BannedUsersService : CrudQueryServiceBase<Ban, BanWithUsersDto, BannedUsersFilterDto>, IBannedUsersService
{
    public BannedUsersService(IRepository<Ban> repository,
        QueryObjectBase<Ban, BanWithUsersDto, BannedUsersFilterDto, IQuery<Ban>> qob) : base(repository, qob)
    {
    }
    public IList<BanWithUsersDto> GetBanned(int id)
    {
        return QueryObject.ExecuteQuery(new BannedUsersFilterDto { BannerId = id }).Items;
    }
}
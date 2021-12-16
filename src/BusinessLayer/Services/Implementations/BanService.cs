using BusinessLayer.DataTransferObjects;
using BusinessLayer.DataTransferObjects.Filters;
using BusinessLayer.QueryObjects;
using BusinessLayer.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.Services.Implementations;

public class BanService: CrudQueryServiceBase<Ban, BanDto, BanFilterDto>, IBanService
{
    public BanService(IRepository<Ban> repository, QueryObjectBase<Ban, BanDto, BanFilterDto, IQuery<Ban>> qob) : base(repository, qob)
    {
    }
}
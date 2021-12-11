using AutoMapper;
using BusinessLayer.DataTransferObjects.QueryDtos;
using BusinessLayer.QueryObjects;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.Services;

public class CrudQueryServiceBase<TEntity, TDto, TFilter> : ICrudQueryServiceBase<TDto>
    where TEntity : class, new()
    where TDto : class
    where TFilter : FilterDtoBase

{
    protected readonly IMapper Mapper;
    protected readonly QueryObjectBase<TEntity, TDto, TFilter, IQuery<TEntity>> QueryObject;
    protected readonly IRepository<TEntity> Repository;

    public CrudQueryServiceBase(IRepository<TEntity> repository,
        QueryObjectBase<TEntity, TDto, TFilter, IQuery<TEntity>> qob)
    {
        Repository = repository;
        Mapper = new Mapper(new MapperConfiguration(MappingConfig.ConfigureMap));
        QueryObject = qob;
    }

    public async Task<TDto> GetAsync(params object[] keyValues)
    {
        var e = await Repository.GetByIdAsync(keyValues);
        return e != null ? Mapper.Map<TDto>(e) : null;
    }

    public async Task CreateAsync(TDto entityDto)
    {
        await Repository.CreateAsync(Mapper.Map<TEntity>(entityDto));
    }

    public void Update(TDto entityDto)
    {
        Repository.Update(Mapper.Map<TEntity>(entityDto));
    }

    public async Task DeleteAsync(params object[] keyValues)
    {
        await Repository.DeleteAsync(keyValues);
    }
}
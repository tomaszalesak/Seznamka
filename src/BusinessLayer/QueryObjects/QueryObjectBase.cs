﻿using AutoMapper;
using BusinessLayer.DataTransferObjects.QueryDtos;
using BusinessLayer.DataTransferObjects.QueryDTOs;
using Infrastructure.Persistence.Query;

namespace BusinessLayer.QueryObjects;

public class QueryObjectBase<TEntity, TDto, TFilter, TQuery> : IQueryObjectBase<TEntity, TDto, TFilter>
    where TEntity : class, new()
    where TQuery : IQuery<TEntity>
    where TFilter : FilterDtoBase
{
    private readonly IMapper _mapper;
    protected IQuery<TEntity> Query;

    public QueryObjectBase(TQuery query)
    {
        _mapper = new Mapper(new MapperConfiguration(MappingConfig.ConfigureMap));
        Query = query;
    }

    public virtual IQuery<TEntity> ApplyFilter(IQuery<TEntity> query, TFilter filter)
    {
        return query;
    }

    public IQuery<TEntity> ApplySorting(IQuery<TEntity> query, TFilter filter)
    {
        if (!string.IsNullOrWhiteSpace(filter.SortAccordingTo))
            query = query.SortBy(filter.SortAccordingTo, filter.UseAscendingOrder);
        return query;
    }

    public QueryResultDto<TDto, TFilter> ExecuteQuery(TFilter filter)
    {
        Query = ApplyFilter(Query, filter);
        Query = ApplySorting(Query, filter);
        Query = filter.RequestedPage == null
            ? Query
            : Query.Page(filter.RequestedPage.Value, filter.PageSize);

        var queryResultDto = _mapper.Map<QueryResultDto<TDto, TFilter>>(Query.ExecuteAsync().Result);
        queryResultDto.Filter = filter;
        return queryResultDto;
    }
}
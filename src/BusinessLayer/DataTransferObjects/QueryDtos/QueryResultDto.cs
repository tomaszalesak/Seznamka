using BusinessLayer.DataTransferObjects.QueryDtos;

namespace BusinessLayer.DataTransferObjects.QueryDTOs;

public class QueryResultDto<TEntityDto, TFilter> where TFilter : FilterDtoBase
{
    public long TotalItemsCount { get; set; }
    public int? RequestedPageNumber { get; set; }
    public int PageSize { get; set; }
    public IList<TEntityDto> Items { get; set; }
    public bool PagingEnabled { get; set; }
    public TFilter Filter { get; set; }
}
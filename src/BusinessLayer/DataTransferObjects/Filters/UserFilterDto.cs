using BusinessLayer.DataTransferObjects.QueryDtos;

namespace BusinessLayer.DataTransferObjects.Filters;

public class UserFilterDto : FilterDtoBase
{
    public string Username { get; set; }
}
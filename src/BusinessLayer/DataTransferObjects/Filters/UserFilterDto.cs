using BusinessLayer.DataTransferObjects.QueryDtos;

namespace BusinessLayer.DataTransferObjects.Filters;

public class UserFilterDto : FilterDtoBase
{
    public string Name { get; set; }
    public string Username { get; set; }
}
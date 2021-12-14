using BusinessLayer.DataTransferObjects.QueryDtos;

namespace BusinessLayer.DataTransferObjects.Filters;

public class UsernameUserFilterDto : FilterDtoBase
{
    public string Username { get; set; }
}


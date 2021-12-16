using BusinessLayer.DataTransferObjects.QueryDtos;

namespace BusinessLayer.DataTransferObjects.Filters;

public class BanFilterDto : FilterDtoBase
{
}

public class BannedUsersFilterDto : FilterDtoBase
{
    public int? BannerId { get; set; }
}


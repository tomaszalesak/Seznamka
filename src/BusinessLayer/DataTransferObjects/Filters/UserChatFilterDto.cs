using BusinessLayer.DataTransferObjects.QueryDtos;

namespace BusinessLayer.DataTransferObjects.Filters;

public class UserChatFilterDto : FilterDtoBase
{
    public int? UserId { get; set; }
}
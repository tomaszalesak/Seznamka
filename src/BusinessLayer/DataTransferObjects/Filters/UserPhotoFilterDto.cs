using BusinessLayer.DataTransferObjects.QueryDtos;

namespace BusinessLayer.DataTransferObjects.Filters;

public class UserPhotoFilterDto : FilterDtoBase
{
    public string Username { get; set; }
}

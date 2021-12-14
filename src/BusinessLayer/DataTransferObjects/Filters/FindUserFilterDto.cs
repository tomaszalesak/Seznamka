using BusinessLayer.DataTransferObjects.QueryDtos;

namespace BusinessLayer.DataTransferObjects.Filters;

public class FindUserFilterDto : FilterDtoBase
{
    public string OmitUserByUsername { get; set; }
    public UserAgeFilterDto Age { get; set; }
    public UserHeightFilterDto Height { get; set; }
    public UserWeightDto Weight { get; set; }
}

public class UserAgeFilterDto
{
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
}

public class UserWeightDto
{
    public int MinWeight { get; set; }

    public int MaxWeight { get; set; }
}

public class UserHeightFilterDto
{
    public int MinHeight { get; set; }

    public int MaxHeight { get; set; }
}
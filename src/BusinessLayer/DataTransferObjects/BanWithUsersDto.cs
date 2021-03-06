namespace BusinessLayer.DataTransferObjects;

public class BanWithUsersDto : BaseDto
{
    public int BannedId { get; set; }

    public UserNamesDto Banned { get; set; }

    public int BannerId { get; set; }

    public UserNamesDto Banner { get; set; }
}
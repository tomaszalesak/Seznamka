namespace BusinessLayer.DataTransferObjects;

public class BanWithUsernameDto : BaseDto
{
    public int BannedId { get; set; }
    public int BannerId { get; set; }
    
    public UserNamesDto Banned { get; set; }
    public UserNamesDto Banner { get; set; }
}
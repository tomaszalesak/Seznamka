namespace BusinessLayer.DataTransferObjects;

public class BanDto : BaseDto
{
    public int BannedId { get; set; }
    public int BannerId { get; set; }
}
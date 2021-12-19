namespace BusinessLayer.DataTransferObjects;

public class ChatUserNameDto : BaseDto
{
    public string Name { get; set; }

    public IList<UserNamesDto> Users { get; set; }

    public IList<MessageDto> Messages { get; set; }
}
namespace BusinessLayer.DataTransferObjects;

public class ChatDto : BaseDto
{
    public string Name { get; set; }

    public IList<UserChatDto> Users { get; set; }

    public IList<MessageDto> Messages { get; set; }
}
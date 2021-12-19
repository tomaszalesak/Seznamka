namespace BusinessLayer.DataTransferObjects;

public class UserChatDto
{
    public int UserId { get; set; }
    public UserDto User { get; set; }
    public int ChatId { get; set; }
    public ChatDto Chat { get; set; }
}
namespace BusinessLayer.DataTransferObjects;

public class ChatDto : BaseDto
{
    public string Name { get; set; }
    
    public virtual UserDto MemberOne { get; set; }

    public int MemberTwoId { get; set; }

    public virtual UserDto MemberTwo { get; set; }

    public virtual IList<MessageDto> Messages { get; set; }
}
namespace BusinessLayer.DataTransferObjects;

public class MessageDto
{
    public int AuthorId { get; set; }
    public int ChatId { get; set; }
    public string Text { get; set; }
    public DateTime SendTime { get; set; }
}
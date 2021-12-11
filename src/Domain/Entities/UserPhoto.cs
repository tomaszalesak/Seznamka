namespace Domain.Entities;

public class UserPhoto : BaseEntity
{
    public int UserId { get; set; }

    public virtual User User { get; set; }

    public byte[] Image { get; set; }
}

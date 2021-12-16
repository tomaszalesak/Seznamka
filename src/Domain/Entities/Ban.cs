namespace Domain.Entities;

public class Ban : BaseEntity
{
    public int BannedId { get; set; }

    public virtual User Banned { get; set; }

    public int BannerId { get; set; }

    public virtual User Banner { get; set; }
}
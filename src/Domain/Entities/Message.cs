using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Message : BaseEntity
{
    public int AuthorId { get; set; }
    public virtual User Author { get; set; }
    public int ChatId { get; set; }
    public virtual Chat Chat { get; set; }

    [Required]
    [MaxLength(255)]
    public string Text { get; set; }

    public DateTime SendTime { get; set; }
}

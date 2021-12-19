using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Chat : BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public virtual IList<UserChat> Users { get; } = new List<UserChat>();

    public virtual IList<Message> Messages { get; } = new List<Message>();
}

using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Chat : BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public int MemberOneId { get; set; }

    public virtual User MemberOne { get; set; }

    public int MemberTwoId { get; set; }

    public virtual User MemberTwo { get; set; }

    public virtual IList<Message> Messages { get; } = new List<Message>();
}

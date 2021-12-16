using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User : BaseEntity
{
    [Required]
    [MaxLength(20)]
    public string Name { get; set; }

    [Required]
    [MaxLength(20)]
    public string Surname { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    [Required]
    public DateTime Birthdate { get; set; }

    [Required]
    public Gender Gender { get; set; }

    [Required]
    public int Height { get; set; }

    [Required]
    public int Weight { get; set; }

    [MaxLength(255)]
    public string Bio { get; set; }

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public virtual IList<Chat> Chats { get; } = new List<Chat>();

    public virtual IList<Ban> ReceivedBans { get; } = new List<Ban>();
    
    public virtual IList<Ban> MyBans { get; } = new List<Ban>();
    
    public virtual IList<Friendship> Friendships { get; } = new List<Friendship>();

    public virtual Preferences Preferences { get; set; }

    public virtual IList<UserPhoto> Photos { get; } = new List<UserPhoto>();
}

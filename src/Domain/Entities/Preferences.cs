using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Preferences : BaseEntity
{
    public int UserId { get; set; }

    public virtual User User { get; set; }

    [Required]
    public int MinAge { get; set; }

    [Required]
    public int MaxAge { get; set; }

    [Required]
    public int MinWeight { get; set; }

    [Required]
    public int MaxWeight { get; set; }

    [Required]
    public int MinHeight { get; set; }

    [Required]
    public int MaxHeight { get; set; }

    [Required]
    public int GpsRadius { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Surname { get; set; }
        
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
        
        public Coordinates Location { get; set; }
        
        public virtual ICollection<BlockedUser> BlockedUsers { get; set; }
        
        public virtual ICollection<Friendship> Friendships { get; set; }
        
        public Preferences PreferencesId { get; set; }
        
        [ForeignKey(nameof(PreferencesId))]
        public Preferences Preferences { get; set; }
        
        public virtual ICollection<UserPhoto> Photos { get; set; }
    }
}
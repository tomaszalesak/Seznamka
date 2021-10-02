using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities
{
    public class Chat : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        public int UserOneId { get; set; }
        
        [ForeignKey(nameof(UserOneId))]
        public virtual User UserOne { get; set; }

        public int UserTwoId { get; set; }
        
        [ForeignKey(nameof(UserTwoId))]
        public virtual User UserTwo { get; set; }
        
        public virtual ICollection<Message> Messages { get; set; }
    }
}
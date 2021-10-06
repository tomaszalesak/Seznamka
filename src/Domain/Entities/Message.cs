using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Message : BaseEntity
    {
        public int ChatUser1Id { get; set; }

        public int ChatUser2Id { get; set; }

        public virtual Chat Chat { get; set; }

        [Required]
        [MaxLength(255)]
        public string Text { get; set; }

        public DateTime SendTime { get; set; }
    }
}
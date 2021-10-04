using System;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities
{
    public class Message : BaseEntity
    {
        public virtual Chat Chat { get; set; }

        [Required] [MaxLength(255)]
        public string Text { get; set; }

        public DateTime SendTime { get; set; }
    }
}
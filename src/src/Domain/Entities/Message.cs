using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities
{
    public class Message : BaseEntity
    {
        public int ChatId { get; set; }
        
        [ForeignKey(nameof(ChatId))]
        public virtual Chat Chat { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Text { get; set; }
    }
}
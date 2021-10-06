using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Chat
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int User1Id { get; set; }

        public virtual User User1 { get; set; }

        public int User2Id { get; set; }

        public virtual User User2 { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
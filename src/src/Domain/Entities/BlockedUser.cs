using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities
{
    public class BlockedUser : BaseEntity
    {
        public int UserId { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public int BlockedUserId { get; set; }
        
        [ForeignKey(nameof(BlockedUserId))]
        public virtual User Blocked { get; set; }
    }
}
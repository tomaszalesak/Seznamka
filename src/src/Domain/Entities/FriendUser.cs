using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities
{
    public class FriendUser : BaseEntity
    {
        public int UserId { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public int FriendId { get; set; }
        
        [ForeignKey(nameof(FriendId))]
        public virtual User Friend { get; set; }
    }
}
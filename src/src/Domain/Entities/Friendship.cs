﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Friendship
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int FriendId { get; set; }

        public virtual User Friend { get; set; }
    }
}
using Domain.Entities;
using System.Collections.Generic;

namespace Application.DTOs
{
    class ChatGetDto
    {
        public string Name { get; set; }
        public virtual User MemberOne { get; set; }
        public virtual User MemberTwo { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}

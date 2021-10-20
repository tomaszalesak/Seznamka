using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    class ChatGetDto
    {
        public string Name { get; set; }
        public virtual User MemberOne { get; set; }
        public virtual User MemberTwo { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}

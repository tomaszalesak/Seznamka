using Domain.Entities;
using System;

namespace Application.DTOs
{
    class MessageGetDto
    {
        public virtual User Author { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; }
    }
}

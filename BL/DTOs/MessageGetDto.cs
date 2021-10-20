using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    class MessageGetDto
    {
        public virtual User Author { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; }
    }
}

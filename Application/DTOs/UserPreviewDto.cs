using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    class UserPreviewDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Bio { get; set; }
        public UserPhoto Photo { get; set; }
    }
}

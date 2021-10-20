using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Enums;
namespace BL.DTOs
{
    class UserGetDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Bio { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public virtual ICollection<UserPhoto> Photos { get; set; }
    }
}

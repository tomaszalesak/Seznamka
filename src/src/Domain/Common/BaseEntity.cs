﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
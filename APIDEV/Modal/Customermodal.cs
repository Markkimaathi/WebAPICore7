﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIDEV.Modal
{
    public class Customermodal
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Category { get; set; }

        public int IsActive { get; set; }

        public string? Statusname { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIDEV.Repos.Models;

public partial class Brand
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Category { get; set; }

    public int IsActive { get; set; }
}

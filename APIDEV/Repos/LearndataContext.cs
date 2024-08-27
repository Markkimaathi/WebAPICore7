using System;
using System.Collections.Generic;
using APIDEV.Repos.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDEV.Repos;

public partial class LearndataContext : DbContext
{
    public LearndataContext()
    {
    }

    public LearndataContext(DbContextOptions<LearndataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<TblRefreshtoken> TblRefreshtokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

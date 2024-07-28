using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EtiqaWebApp1.Models;

public partial class FreelancerDbContext : DbContext
{
    public FreelancerDbContext(DbContextOptions<FreelancerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MstUser> MstUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MstUser>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Uname }).HasName("PK__MST_USER__DE6ECCBB5AED2195");

            entity.ToTable("MST_USER");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Uname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("uname");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Hobby)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("hobby");
            entity.Property(e => e.Phonenum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phonenum");
            entity.Property(e => e.Skillset)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("skillset");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

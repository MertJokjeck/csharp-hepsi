using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace todolist.Models;

public partial class Atp11Context : DbContext
{
    public Atp11Context()
    {
    }

    public Atp11Context(DbContextOptions<Atp11Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Liste> Listes { get; set; }

    public virtual DbSet<todo> todos { get; set; }

    public virtual DbSet<Todolist> Todolists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=atp11", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_turkish_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Liste>(entity =>
        {
            entity.HasKey(e => e.Sirano).HasName("PRIMARY");

            entity.ToTable("liste");

            entity.Property(e => e.Sirano).HasColumnName("sirano");
            entity.Property(e => e.Ad)
                .HasMaxLength(20)
                .HasColumnName("ad");
            entity.Property(e => e.Bolum)
                .HasMaxLength(30)
                .HasColumnName("bolum");
            entity.Property(e => e.Dogumtarihi).HasColumnName("dogumtarihi");
        });

        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("todo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsComplated)
                .HasColumnType("bit(1)")
                .HasColumnName("isComplated");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Todolist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("todolist");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .HasColumnName("title");
            entity.Property(e => e.İsCompleted).HasColumnType("bit(1)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

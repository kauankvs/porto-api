using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PortoAPI.Models;

public partial class PortoApiDbContext : DbContext
{
    public PortoApiDbContext()
    {
    }

    public PortoApiDbContext(DbContextOptions<PortoApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Container> Containers { get; set; }

    public virtual DbSet<Movimentacao> Movimentacaos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=PortoApiDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Container>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Containe__3214EC07D4EC9517");

            entity.ToTable("Container");

            entity.Property(e => e.Categoria)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Cliente)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NumeroDeSerie)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Movimentacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Moviment__3214EC070EC29ECB");

            entity.ToTable("Movimentacao");

            entity.Property(e => e.Cliente)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Fim).HasColumnType("datetime");
            entity.Property(e => e.Inicio).HasColumnType("datetime");
            entity.Property(e => e.NumeroDeContainer)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjetoMVCMain.Models;

public partial class DbSistemaTransporteContext : DbContext
{
    public DbSistemaTransporteContext()
    {
    }

    public DbSistemaTransporteContext(DbContextOptions<DbSistemaTransporteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Entrega> Entregas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC03LAB2838\\SENAI;Database=DB_Sistema_Transporte;User id=sa;Password=senai.123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entrega>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Entrega__06370DADAE63B7B1");

            entity.ToTable("Entrega");

            entity.Property(e => e.DescricaoCarga)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Destino)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Peso).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

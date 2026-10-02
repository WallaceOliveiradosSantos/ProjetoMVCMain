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

    public virtual DbSet<Veiculo> Veiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SENAI;Database=DB_Sistema_Transporte;User id=sa; Password=senai.123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Veiculo>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Veiculo__06370DAD5C6363AE");

            entity.ToTable("Veiculo");

            entity.HasIndex(e => e.Placa, "UQ__Veiculo__8310F99DBC284F28").IsUnique();

            entity.Property(e => e.CapacidadeCarga).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Placa)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

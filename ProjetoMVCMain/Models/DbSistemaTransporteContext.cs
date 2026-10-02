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

    public virtual DbSet<Motorista> Motorista { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC03LAB2819\\SENAI;Database=DB_Sistema_Transporte;User id=sa; Password=senai.123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Motorista>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Motorist__06370DAD0760AC56");

            entity.HasIndex(e => e.Cpf, "UQ__Motorist__C1F8973190CE6042").IsUnique();

            entity.HasIndex(e => e.Cnh, "UQ__Motorist__C1FF677515FF143E").IsUnique();

            entity.Property(e => e.Cnh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CNH");
            entity.Property(e => e.Cpf)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

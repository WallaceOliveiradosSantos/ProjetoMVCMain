using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjetoMVCMain.Models;

public partial class DbHotelContext : DbContext
{
    public DbHotelContext()
    {
    }

    public DbHotelContext(DbContextOptions<DbHotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hospede> Hospedes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC03LAB2824\\SENAI;Database=DB_Hotel;User id=sa;  Password=senai.123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hospede>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Hospede__06370DADDB585570");

            entity.ToTable("Hospede");

            entity.HasIndex(e => e.Cpf, "UQ__Hospede__C1F897314D78FB99").IsUnique();

            entity.Property(e => e.Cpf)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
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

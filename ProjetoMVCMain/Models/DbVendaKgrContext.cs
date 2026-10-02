using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjetoMVCMain.Models;

public partial class DbVendaKgrContext : DbContext
{
    private DbSet<Fornecedor> fornecedores;

    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbVendaKgrContext()
    {
    }

    public DbVendaKgrContext(DbContextOptions<DbVendaKgrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fornecedor> Fornecedors { get => fornecedores; set => fornecedores = value; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC03LAB2821\\SENAI;Database=DB_VendaKGR;User id=sa;Password=senai.123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fornecedor>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Forneced__06370DAD1F34AA2A");

            entity.ToTable("Fornecedor");

            entity.HasIndex(e => e.Cnpj, "UQ__Forneced__AA57D6B46C9E5EE4").IsUnique();

            entity.Property(e => e.Cnpj)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("CNPJ");
            entity.Property(e => e.RazaoSocial)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    internal static object CreateBuilder(string[] args)
    {
        throw new NotImplementedException();
    }
}

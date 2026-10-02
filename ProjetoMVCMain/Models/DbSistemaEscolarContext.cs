using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjetoMVCMain.Models;

public partial class DbSistemaEscolarContext : DbContext
{
    public DbSistemaEscolarContext()
    {
    }

    public DbSistemaEscolarContext(DbContextOptions<DbSistemaEscolarContext> options)
        : base(options)
    {
    }

    public DbSet<Aluno> Alunos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=DB_Sistema_Escolar;User id=sa;Password=mari2610;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Aluno__06370DAD1EBF86EC");

            entity.ToTable("Aluno");

            entity.HasIndex(e => e.Cpf, "UQ__Aluno__C1F8973151EBE7E8").IsUnique();

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

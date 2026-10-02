using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMVCMain.Models;

public partial class Aluno
{
    [Key]
    public int Codigo { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public DateOnly DataNascimento { get; set; }

    public string? Telefone { get; set; }
}

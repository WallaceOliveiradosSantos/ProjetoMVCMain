using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMVCMain.Models;

public partial class Professor
{
    [Key]
    public int Codigo { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Especialidade { get; set; } = null!;

    public decimal Salario { get; set; }
}

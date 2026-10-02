using System;
using System.Collections.Generic;

namespace ProjetoMVCMain.Models;

public partial class Cliente
{
    public int Codigo { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string? Telefone { get; set; }
}

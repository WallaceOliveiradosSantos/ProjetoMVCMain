using System;
using System.Collections.Generic;

namespace ProjetoMVCMain.Models;

public partial class Fornecedor
{
    public int Codigo { get; set; }

    public string RazaoSocial { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public string? Telefone { get; set; }
}

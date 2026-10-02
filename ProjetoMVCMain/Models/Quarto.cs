using System;
using System.Collections.Generic;

namespace ProjetoMVCMain.Models;

public partial class Quarto
{
    public int Codigo { get; set; }

    public int Numero { get; set; }

    public string Tipo { get; set; } = null!;

    public decimal ValorDiaria { get; set; }

    public string Status { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ProjetoMVCMain.Models;

public partial class Entrega
{
    public int Codigo { get; set; }

    public string Destino { get; set; } = null!;

    public string DescricaoCarga { get; set; } = null!;

    public decimal Peso { get; set; }

    public DateOnly DataEntrega { get; set; }

    public string Status { get; set; } = null!;
}

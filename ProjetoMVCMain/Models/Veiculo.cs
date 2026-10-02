using System;
using System.Collections.Generic;

namespace ProjetoMVCMain.Models;

public partial class Veiculo
{
    public int Codigo { get; set; }

    public string Placa { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public int Ano { get; set; }

    public decimal CapacidadeCarga { get; set; }
}

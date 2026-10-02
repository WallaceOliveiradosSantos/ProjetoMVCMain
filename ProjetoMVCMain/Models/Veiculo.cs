using System;
using System.Collections.Generic;

namespace ProjetoMVCMain.Models;

public class Veiculo
{
    public int Codigo { get; set; }

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public int Ano { get; set; }

    public string Placa { get; set; } = null!;
}

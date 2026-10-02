using System;
using System.Collections.Generic;

namespace ProjetoMVCMain.Models;

public partial class Curso
{
    public int Codigo { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public int CargaHoraria { get; set; }

    public decimal Valor { get; set; }
}

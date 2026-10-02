using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ProjetoMVCMain.Models;

public partial class Servico
{
    public int Codigo { get; set; }

    public string Descricao { get; set; } = null!;

    public decimal Valor { get; set; }

    public int TempoEstimado { get; set; }

    public string Status { get; set; } = null!;

}

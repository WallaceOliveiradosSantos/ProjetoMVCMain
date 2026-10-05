using System;
using System.Collections.Generic;

namespace ProjetoMVCMain.Models;

public partial class Reserva
{
    public int Codigo { get; set; }

    public DateOnly DataEntrada { get; set; }

    public DateOnly DataSaida { get; set; }

    public int QuantidadeHospedes { get; set; }

    public decimal ValorTotal { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVCMain.Models;

[Table("Consulta")]
public partial class Consulta
{
    [Key]
    public int Codigo { get; set; }

    [Display(Name = "Data da Consulta")]
    public DateTime DataConsulta { get; set; }

    [Display(Name = "Médico")]
    public string Especialidade { get; set; } = null!;

    [Display(Name = "Sintomas")]
    public string Status { get; set; } = null!;

    [Display(Name = "Observação")]
    public string? Observacao { get; set; }
}
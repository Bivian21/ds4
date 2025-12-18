using System.ComponentModel.DataAnnotations;

namespace MatriculaEscolarIPTC.Models;

public class Horario
{
    public int Id { get; set; }

    [Required]
    public int GrupoId { get; set; }
    public Grupo? Grupo { get; set; }

    [Required]
    public DayOfWeek Dia { get; set; } = DayOfWeek.Monday;

    [Required]
    public TimeOnly HoraInicio { get; set; } = new TimeOnly(8, 0);

    [Required]
    public TimeOnly HoraFin { get; set; } = new TimeOnly(9, 0);

    [StringLength(30)]
    public string Aula { get; set; } = "A-1";

    public bool Activo { get; set; } = true;
}

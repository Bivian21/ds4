using System.ComponentModel.DataAnnotations;

namespace MatriculaEscolarIPTC.Models;

public class Grupo
{
    public int Id { get; set; }

    [Required, StringLength(30)]
    public string Periodo { get; set; } = $"II-{DateTime.Now.Year}";

    [Required, StringLength(50)]
    public string Seccion { get; set; } = "A";

    [Required]
    public int MateriaId { get; set; }
    public Materia? Materia { get; set; }

    [Required]
    public int ProfesorId { get; set; }
    public Profesor? Profesor { get; set; }

    [Range(1, 60)]
    public int Cupo { get; set; } = 35;

    [StringLength(20)]
    public string Grado { get; set; } = "7°";

    public ICollection<Horario> Horarios { get; set; } = new List<Horario>();
    public ICollection<MatriculaDetalle> Matriculas { get; set; } = new List<MatriculaDetalle>();
}

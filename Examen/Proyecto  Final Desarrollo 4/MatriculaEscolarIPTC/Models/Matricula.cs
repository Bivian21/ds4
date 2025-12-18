using System.ComponentModel.DataAnnotations;

namespace MatriculaEscolarIPTC.Models;

public class Matricula
{
    public int Id { get; set; }

    [Required]
    public int EstudianteId { get; set; }
    public Estudiante? Estudiante { get; set; }

    [Required, StringLength(30)]
    public string Periodo { get; set; } = $"II-{DateTime.Now.Year}";

    public DateTime Fecha { get; set; } = DateTime.Now;

    public ICollection<MatriculaDetalle> Detalles { get; set; } = new List<MatriculaDetalle>();
}

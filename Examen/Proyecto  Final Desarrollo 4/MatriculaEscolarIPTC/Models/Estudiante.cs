using System.ComponentModel.DataAnnotations;

namespace MatriculaEscolarIPTC.Models;

public class Estudiante
{
    public int Id { get; set; }

    [Required, StringLength(20)]
    public string Cedula { get; set; } = "";

    [Required, StringLength(120)]
    public string NombreCompleto { get; set; } = "";

    [StringLength(120)]
    public string? Email { get; set; }

    [StringLength(30)]
    public string? Telefono { get; set; }

    [StringLength(30)]
    public string Grado { get; set; } = "7°";

    [StringLength(30)]
    public string AnioLectivo { get; set; } = DateTime.Now.Year.ToString();
}

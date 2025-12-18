using System.ComponentModel.DataAnnotations;

namespace MatriculaEscolarIPTC.Models;

public class Profesor
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

    [StringLength(80)]
    public string? Especialidad { get; set; }

    public bool Activo { get; set; } = true;
}

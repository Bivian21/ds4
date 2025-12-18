using System.ComponentModel.DataAnnotations;

namespace MatriculaEscolarIPTC.Models;

public class Materia
{
    public int Id { get; set; }

    [Required, StringLength(15)]
    public string Codigo { get; set; } = "";

    [Required, StringLength(120)]
    public string Nombre { get; set; } = "";

    [Range(1, 10)]
    public int Creditos { get; set; } = 3;

    public bool Activa { get; set; } = true;
}

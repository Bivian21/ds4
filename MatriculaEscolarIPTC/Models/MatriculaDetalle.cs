namespace MatriculaEscolarIPTC.Models;

public class MatriculaDetalle
{
    public int Id { get; set; }

    public int MatriculaId { get; set; }
    public Matricula? Matricula { get; set; }

    public int GrupoId { get; set; }
    public Grupo? Grupo { get; set; }
}

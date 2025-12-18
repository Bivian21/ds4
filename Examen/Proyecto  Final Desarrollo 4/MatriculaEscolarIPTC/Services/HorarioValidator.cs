using MatriculaEscolarIPTC.Data;
using MatriculaEscolarIPTC.Models;
using Microsoft.EntityFrameworkCore;

namespace MatriculaEscolarIPTC.Services;

public class HorarioValidator
{
    private readonly AppDbContext _db;
    public HorarioValidator(AppDbContext db) => _db = db;

    public async Task<(bool ok, string? error)> ValidarAsync(Horario h)
    {
        if (h.HoraFin <= h.HoraInicio)
            return (false, "La hora fin debe ser mayor que la hora inicio.");

        var grupo = await _db.Grupos
            .Include(g => g.Profesor)
            .FirstOrDefaultAsync(g => g.Id == h.GrupoId);

        if (grupo is null) return (false, "Grupo no existe.");

        // Conflicto: mismo grupo, mismo día, solape
        bool Solapa(TimeOnly aIni, TimeOnly aFin, TimeOnly bIni, TimeOnly bFin)
            => aIni < bFin && bIni < aFin;

        var horariosGrupo = await _db.Horarios
            .Where(x => x.GrupoId == h.GrupoId && x.Dia == h.Dia && x.Id != h.Id && x.Activo)
            .ToListAsync();

        if (horariosGrupo.Any(x => Solapa(h.HoraInicio, h.HoraFin, x.HoraInicio, x.HoraFin)))
            return (false, "Conflicto: el grupo ya tiene un horario que se cruza en ese día/hora.");

        // Conflicto: profesor en otro grupo, mismo día, solape
        var profesorId = grupo.ProfesorId;

        var horariosProfesor = await _db.Horarios
            .Include(x => x.Grupo)
            .Where(x => x.Activo && x.Dia == h.Dia && x.Id != h.Id && x.Grupo!.ProfesorId == profesorId)
            .ToListAsync();

        if (horariosProfesor.Any(x => Solapa(h.HoraInicio, h.HoraFin, x.HoraInicio, x.HoraFin)))
            return (false, "Conflicto: el profesor ya está asignado a otro grupo en ese día/hora.");

        // Conflicto aula (opcional): misma aula, mismo día, solape
        if (!string.IsNullOrWhiteSpace(h.Aula))
        {
            var aula = h.Aula.Trim();
            var horariosAula = await _db.Horarios
                .Where(x => x.Activo && x.Dia == h.Dia && x.Aula == aula && x.Id != h.Id)
                .ToListAsync();

            if (horariosAula.Any(x => Solapa(h.HoraInicio, h.HoraFin, x.HoraInicio, x.HoraFin)))
                return (false, "Conflicto: el aula ya está ocupada en ese día/hora.");
        }

        return (true, null);
    }
}

using MatriculaEscolarIPTC.Data;
using MatriculaEscolarIPTC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatriculaEscolarIPTC.Controllers;

[Authorize(Roles = "Admin,Secretaria")]
public class MatriculasController : Controller
{
    private readonly AppDbContext _db;
    public MatriculasController(AppDbContext db) => _db = db;

    public async Task<IActionResult> Index(string? periodo, string? q)
    {
        var query = _db.Matriculas
            .Include(x => x.Estudiante)
            .Include(x => x.Detalles)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(periodo))
            query = query.Where(x => x.Periodo == periodo);

        if (!string.IsNullOrWhiteSpace(q))
            query = query.Where(x => x.Estudiante!.Cedula.Contains(q) || x.Estudiante!.NombreCompleto.Contains(q));

        ViewBag.Periodo = periodo;
        ViewBag.Q = q;

        return View(await query.OrderByDescending(x => x.Fecha).ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Estudiantes = await _db.Estudiantes.OrderBy(x => x.NombreCompleto).ToListAsync();
        return View(new Matricula());
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Matricula m)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Estudiantes = await _db.Estudiantes.OrderBy(x => x.NombreCompleto).ToListAsync();
            return View(m);
        }

        _db.Matriculas.Add(m);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Matrícula creada. Ahora agregue materias/grupos.";
        return RedirectToAction(nameof(Edit), new { id = m.Id });
    }

    public async Task<IActionResult> Edit(int id)
    {
        var m = await _db.Matriculas
            .Include(x => x.Estudiante)
            .Include(x => x.Detalles).ThenInclude(d => d.Grupo)!.ThenInclude(g => g.Materia)
            .Include(x => x.Detalles).ThenInclude(d => d.Grupo)!.ThenInclude(g => g.Profesor)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (m is null) return NotFound();

        ViewBag.Grupos = await _db.Grupos
            .Include(g => g.Materia)
            .Include(g => g.Profesor)
            .OrderBy(g => g.Grado).ThenBy(g => g.Seccion).ThenBy(g => g.Materia!.Codigo)
            .ToListAsync();

        return View(m);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddGrupo(int matriculaId, int grupoId)
    {
        var m = await _db.Matriculas
            .Include(x => x.Detalles)
            .FirstOrDefaultAsync(x => x.Id == matriculaId);

        if (m is null) return NotFound();

        if (m.Detalles.Any(d => d.GrupoId == grupoId))
        {
            TempData["err"] = "Ese grupo ya está agregado.";
            return RedirectToAction(nameof(Edit), new { id = matriculaId });
        }

        // Validar choques de horario para el estudiante
        var gruposActualesIds = m.Detalles.Select(d => d.GrupoId).ToList();
        var gruposActuales = await _db.Grupos
            .Include(g => g.Horarios)
            .Where(g => gruposActualesIds.Contains(g.Id))
            .ToListAsync();

        var grupoNuevo = await _db.Grupos
            .Include(g => g.Horarios)
            .FirstOrDefaultAsync(g => g.Id == grupoId);

        if (grupoNuevo is null)
        {
            TempData["err"] = "Grupo no existe.";
            return RedirectToAction(nameof(Edit), new { id = matriculaId });
        }

        bool Solapa(TimeOnly aIni, TimeOnly aFin, TimeOnly bIni, TimeOnly bFin) => aIni < bFin && bIni < aFin;

        foreach (var g in gruposActuales)
        {
            foreach (var h1 in g.Horarios.Where(x => x.Activo))
            foreach (var h2 in grupoNuevo.Horarios.Where(x => x.Activo))
            {
                if (h1.Dia == h2.Dia && Solapa(h1.HoraInicio, h1.HoraFin, h2.HoraInicio, h2.HoraFin))
                {
                    TempData["err"] = "Choque de horario: esa materia/grupo se cruza con otra ya matriculada.";
                    return RedirectToAction(nameof(Edit), new { id = matriculaId });
                }
            }
        }

        m.Detalles.Add(new MatriculaDetalle { GrupoId = grupoId });
        await _db.SaveChangesAsync();
        TempData["ok"] = "Grupo agregado a la matrícula.";
        return RedirectToAction(nameof(Edit), new { id = matriculaId });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveDetalle(int detalleId)
    {
        var d = await _db.MatriculaDetalles.FindAsync(detalleId);
        if (d is null) return NotFound();

        var mid = d.MatriculaId;
        _db.MatriculaDetalles.Remove(d);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Materia/grupo removido.";
        return RedirectToAction(nameof(Edit), new { id = mid });
    }

    public async Task<IActionResult> Delete(int id)
    {
        var m = await _db.Matriculas.Include(x => x.Estudiante).FirstOrDefaultAsync(x => x.Id == id);
        return m is null ? NotFound() : View(m);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var m = await _db.Matriculas.FindAsync(id);
        if (m is null) return NotFound();

        _db.Matriculas.Remove(m);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Matrícula eliminada.";
        return RedirectToAction(nameof(Index));
    }
}

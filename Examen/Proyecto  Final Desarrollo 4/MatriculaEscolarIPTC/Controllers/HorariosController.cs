using MatriculaEscolarIPTC.Data;
using MatriculaEscolarIPTC.Models;
using MatriculaEscolarIPTC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatriculaEscolarIPTC.Controllers;

[Authorize(Roles = "Admin,Secretaria")]
public class HorariosController : Controller
{
    private readonly AppDbContext _db;
    private readonly HorarioValidator _validator;

    public HorariosController(AppDbContext db, HorarioValidator validator)
    {
        _db = db;
        _validator = validator;
    }

    public async Task<IActionResult> Index(int? grupoId)
    {
        var q = _db.Horarios
            .Include(x => x.Grupo)!.ThenInclude(g => g.Materia)
            .Include(x => x.Grupo)!.ThenInclude(g => g.Profesor)
            .AsQueryable();

        if (grupoId.HasValue) q = q.Where(x => x.GrupoId == grupoId.Value);

        ViewBag.GrupoId = grupoId;
        return View(await q.OrderBy(x => x.Dia).ThenBy(x => x.HoraInicio).ToListAsync());
    }

    public async Task<IActionResult> Create(int? grupoId)
    {
        ViewBag.Grupos = await _db.Grupos.Include(g => g.Materia).Include(g => g.Profesor)
            .OrderBy(g => g.Grado).ThenBy(g => g.Seccion).ToListAsync();

        return View(new Horario { GrupoId = grupoId ?? 0 });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Horario h)
    {
        var (ok, err) = await _validator.ValidarAsync(h);
        if (!ok) ModelState.AddModelError("", err!);

        if (!ModelState.IsValid)
        {
            ViewBag.Grupos = await _db.Grupos.Include(g => g.Materia).Include(g => g.Profesor)
                .OrderBy(g => g.Grado).ThenBy(g => g.Seccion).ToListAsync();
            return View(h);
        }

        _db.Horarios.Add(h);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Horario creado.";
        return RedirectToAction(nameof(Index), new { grupoId = h.GrupoId });
    }

    public async Task<IActionResult> Edit(int id)
    {
        var h = await _db.Horarios.FindAsync(id);
        if (h is null) return NotFound();

        ViewBag.Grupos = await _db.Grupos.Include(g => g.Materia).Include(g => g.Profesor)
            .OrderBy(g => g.Grado).ThenBy(g => g.Seccion).ToListAsync();
        return View(h);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Horario h)
    {
        if (id != h.Id) return BadRequest();

        var (ok, err) = await _validator.ValidarAsync(h);
        if (!ok) ModelState.AddModelError("", err!);

        if (!ModelState.IsValid)
        {
            ViewBag.Grupos = await _db.Grupos.Include(g => g.Materia).Include(g => g.Profesor)
                .OrderBy(g => g.Grado).ThenBy(g => g.Seccion).ToListAsync();
            return View(h);
        }

        _db.Update(h);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Horario actualizado.";
        return RedirectToAction(nameof(Index), new { grupoId = h.GrupoId });
    }

    public async Task<IActionResult> Delete(int id)
    {
        var h = await _db.Horarios
            .Include(x => x.Grupo)!.ThenInclude(g => g.Materia)
            .Include(x => x.Grupo)!.ThenInclude(g => g.Profesor)
            .FirstOrDefaultAsync(x => x.Id == id);

        return h is null ? NotFound() : View(h);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var h = await _db.Horarios.FindAsync(id);
        if (h is null) return NotFound();

        var grupoId = h.GrupoId;
        _db.Horarios.Remove(h);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Horario eliminado.";
        return RedirectToAction(nameof(Index), new { grupoId });
    }
}

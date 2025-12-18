using MatriculaEscolarIPTC.Data;
using MatriculaEscolarIPTC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatriculaEscolarIPTC.Controllers;

[Authorize(Roles = "Admin,Secretaria")]
public class EstudiantesController : Controller
{
    private readonly AppDbContext _db;
    public EstudiantesController(AppDbContext db) => _db = db;

    public async Task<IActionResult> Index(string? q)
    {
        var query = _db.Estudiantes.AsQueryable();
        if (!string.IsNullOrWhiteSpace(q))
            query = query.Where(x => x.Cedula.Contains(q) || x.NombreCompleto.Contains(q));

        ViewBag.Q = q;
        return View(await query.OrderBy(x => x.NombreCompleto).ToListAsync());
    }

    public IActionResult Create() => View(new Estudiante());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Estudiante e)
    {
        if (!ModelState.IsValid) return View(e);

        _db.Estudiantes.Add(e);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Estudiante creado.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var e = await _db.Estudiantes.FindAsync(id);
        return e is null ? NotFound() : View(e);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Estudiante e)
    {
        if (id != e.Id) return BadRequest();
        if (!ModelState.IsValid) return View(e);

        _db.Update(e);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Estudiante actualizado.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var e = await _db.Estudiantes.FindAsync(id);
        return e is null ? NotFound() : View(e);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var e = await _db.Estudiantes.FindAsync(id);
        if (e is null) return NotFound();

        _db.Estudiantes.Remove(e);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Estudiante eliminado.";
        return RedirectToAction(nameof(Index));
    }
}

using MatriculaEscolarIPTC.Data;
using MatriculaEscolarIPTC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatriculaEscolarIPTC.Controllers;

[Authorize(Roles = "Admin,Secretaria")]
public class ProfesoresController : Controller
{
    private readonly AppDbContext _db;
    public ProfesoresController(AppDbContext db) => _db = db;

    public async Task<IActionResult> Index(string? q)
    {
        var query = _db.Profesores.AsQueryable();
        if (!string.IsNullOrWhiteSpace(q))
            query = query.Where(x => x.Cedula.Contains(q) || x.NombreCompleto.Contains(q));

        ViewBag.Q = q;
        return View(await query.OrderByDescending(x => x.Activo).ThenBy(x => x.NombreCompleto).ToListAsync());
    }

    public IActionResult Create() => View(new Profesor());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Profesor p)
    {
        if (!ModelState.IsValid) return View(p);

        _db.Profesores.Add(p);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Profesor creado.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var p = await _db.Profesores.FindAsync(id);
        return p is null ? NotFound() : View(p);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Profesor p)
    {
        if (id != p.Id) return BadRequest();
        if (!ModelState.IsValid) return View(p);

        _db.Update(p);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Profesor actualizado.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var p = await _db.Profesores.FindAsync(id);
        return p is null ? NotFound() : View(p);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var p = await _db.Profesores.FindAsync(id);
        if (p is null) return NotFound();

        _db.Profesores.Remove(p);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Profesor eliminado.";
        return RedirectToAction(nameof(Index));
    }
}

using MatriculaEscolarIPTC.Data;
using MatriculaEscolarIPTC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatriculaEscolarIPTC.Controllers;

[Authorize(Roles = "Admin,Secretaria")]
public class MateriasController : Controller
{
    private readonly AppDbContext _db;
    public MateriasController(AppDbContext db) => _db = db;

    public async Task<IActionResult> Index(string? q)
    {
        var query = _db.Materias.AsQueryable();
        if (!string.IsNullOrWhiteSpace(q))
            query = query.Where(x => x.Codigo.Contains(q) || x.Nombre.Contains(q));

        ViewBag.Q = q;
        return View(await query.OrderBy(x => x.Codigo).ToListAsync());
    }

    public IActionResult Create() => View(new Materia());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Materia m)
    {
        if (!ModelState.IsValid) return View(m);

        _db.Materias.Add(m);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Materia creada.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var m = await _db.Materias.FindAsync(id);
        return m is null ? NotFound() : View(m);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Materia m)
    {
        if (id != m.Id) return BadRequest();
        if (!ModelState.IsValid) return View(m);

        _db.Update(m);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Materia actualizada.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var m = await _db.Materias.FindAsync(id);
        return m is null ? NotFound() : View(m);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var m = await _db.Materias.FindAsync(id);
        if (m is null) return NotFound();

        _db.Materias.Remove(m);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Materia eliminada.";
        return RedirectToAction(nameof(Index));
    }
}

using MatriculaEscolarIPTC.Data;
using MatriculaEscolarIPTC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MatriculaEscolarIPTC.Controllers;

[Authorize(Roles = "Admin,Secretaria")]
public class GruposController : Controller
{
    private readonly AppDbContext _db;
    public GruposController(AppDbContext db) => _db = db;

    public async Task<IActionResult> Index(string? periodo, string? grado)
    {
        var q = _db.Grupos
            .Include(x => x.Materia)
            .Include(x => x.Profesor)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(periodo))
            q = q.Where(x => x.Periodo == periodo);
        if (!string.IsNullOrWhiteSpace(grado))
            q = q.Where(x => x.Grado == grado);

        ViewBag.Periodo = periodo;
        ViewBag.Grado = grado;

        return View(await q.OrderBy(x => x.Grado).ThenBy(x => x.Seccion).ThenBy(x => x.Materia!.Codigo).ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        await LoadCombos();
        return View(new Grupo());
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Grupo g)
    {
        if (!ModelState.IsValid)
        {
            await LoadCombos();
            return View(g);
        }

        _db.Grupos.Add(g);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Grupo/Sección creada.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var g = await _db.Grupos.FindAsync(id);
        if (g is null) return NotFound();
        await LoadCombos();
        return View(g);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Grupo g)
    {
        if (id != g.Id) return BadRequest();
        if (!ModelState.IsValid)
        {
            await LoadCombos();
            return View(g);
        }

        _db.Update(g);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Grupo actualizado.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var g = await _db.Grupos
            .Include(x => x.Materia)
            .Include(x => x.Profesor)
            .Include(x => x.Horarios)
            .FirstOrDefaultAsync(x => x.Id == id);

        return g is null ? NotFound() : View(g);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var g = await _db.Grupos
            .Include(x => x.Materia)
            .Include(x => x.Profesor)
            .FirstOrDefaultAsync(x => x.Id == id);

        return g is null ? NotFound() : View(g);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var g = await _db.Grupos.FindAsync(id);
        if (g is null) return NotFound();

        _db.Grupos.Remove(g);
        await _db.SaveChangesAsync();
        TempData["ok"] = "Grupo eliminado.";
        return RedirectToAction(nameof(Index));
    }

    private async Task LoadCombos()
    {
        ViewBag.Materias = new SelectList(await _db.Materias.OrderBy(x => x.Codigo).ToListAsync(), "Id", "Nombre");
        ViewBag.Profesores = new SelectList(await _db.Profesores.Where(x => x.Activo).OrderBy(x => x.NombreCompleto).ToListAsync(), "Id", "NombreCompleto");
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PasaportesBP.Data;
using PasaportesBP.Models;

namespace PasaportesBP.Controllers
{
    public class PasaporteController : Controller
    {
        private readonly AppDbContext _context;

        public PasaporteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Pasaporte
        public async Task<IActionResult> Index()
        {
            var pasaportes = await _context.Pasaportes
                .Include(p => p.Solicitante)
                .OrderByDescending(p => p.FechaSolicitud)
                .ToListAsync();

            return View(pasaportes);
        }

        // GET: /Pasaporte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var pasaporte = await _context.Pasaportes
                .Include(p => p.Solicitante)
                .FirstOrDefaultAsync(m => m.PasaporteID == id);

            if (pasaporte == null) return NotFound();

            return View(pasaporte);
        }

        // GET: /Pasaporte/Crear
        public IActionResult Crear()
        {
            ViewData["SolicitanteID"] = new SelectList(_context.Solicitantes.OrderBy(s => s.Apellidos).ThenBy(s => s.Nombres), "SolicitanteID", "NombreCompleto");
            ViewData["Estados"] = GetEstados();
            return View();
        }

        // POST: /Pasaporte/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Pasaporte modelo)
        {
            if (ModelState.IsValid)
            {
                _context.Pasaportes.Add(modelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["SolicitanteID"] = new SelectList(_context.Solicitantes, "SolicitanteID", "NombreCompleto", modelo.SolicitanteID);
            ViewData["Estados"] = GetEstados(modelo.Estado);
            return View(modelo);
        }

        // GET: /Pasaporte/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return NotFound();

            var pasaporte = await _context.Pasaportes.FindAsync(id);
            if (pasaporte == null) return NotFound();

            ViewData["SolicitanteID"] = new SelectList(_context.Solicitantes.OrderBy(s => s.Apellidos).ThenBy(s => s.Nombres), "SolicitanteID", "NombreCompleto", pasaporte.SolicitanteID);
            ViewData["Estados"] = GetEstados(pasaporte.Estado);
            return View(pasaporte);
        }

        // POST: /Pasaporte/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Pasaporte modelo)
        {
            if (id != modelo.PasaporteID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Pasaportes.Any(e => e.PasaporteID == modelo.PasaporteID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["SolicitanteID"] = new SelectList(_context.Solicitantes, "SolicitanteID", "NombreCompleto", modelo.SolicitanteID);
            ViewData["Estados"] = GetEstados(modelo.Estado);
            return View(modelo);
        }

        // GET: /Pasaporte/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null) return NotFound();

            var pasaporte = await _context.Pasaportes
                .Include(p => p.Solicitante)
                .FirstOrDefaultAsync(m => m.PasaporteID == id);

            if (pasaporte == null) return NotFound();

            return View(pasaporte);
        }

        // POST: /Pasaporte/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var pasaporte = await _context.Pasaportes.FindAsync(id);
            if (pasaporte != null)
            {
                _context.Pasaportes.Remove(pasaporte);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetEstados(string? seleccionado = null)
        {
            var estados = new List<string> { "Solicitado", "Aprobado", "Entregado", "Rechazado" };
            return estados.Select(e => new SelectListItem
            {
                Text = e,
                Value = e,
                Selected = (e == seleccionado)
            }).ToList();
        }
    }
}

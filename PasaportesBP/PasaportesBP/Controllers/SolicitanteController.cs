using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasaportesBP.Data;
using PasaportesBP.Models;

namespace PasaportesBP.Controllers
{
    public class SolicitanteController : Controller
    {
        private readonly AppDbContext _context;

        public SolicitanteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Solicitante
        public async Task<IActionResult> Index()
        {
            var lista = await _context.Solicitantes.OrderBy(s => s.Apellidos).ThenBy(s => s.Nombres).ToListAsync();
            return View(lista);
        }

        // GET: /Solicitante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var solicitante = await _context.Solicitantes.FirstOrDefaultAsync(m => m.SolicitanteID == id);
            if (solicitante == null) return NotFound();

            return View(solicitante);
        }

        // GET: /Solicitante/Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: /Solicitante/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Solicitante modelo)
        {
            if (ModelState.IsValid)
            {
                _context.Solicitantes.Add(modelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // GET: /Solicitante/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return NotFound();

            var solicitante = await _context.Solicitantes.FindAsync(id);
            if (solicitante == null) return NotFound();

            return View(solicitante);
        }

        // POST: /Solicitante/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Solicitante modelo)
        {
            if (id != modelo.SolicitanteID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Solicitantes.Any(e => e.SolicitanteID == modelo.SolicitanteID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // GET: /Solicitante/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null) return NotFound();

            var solicitante = await _context.Solicitantes.FirstOrDefaultAsync(m => m.SolicitanteID == id);
            if (solicitante == null) return NotFound();

            return View(solicitante);
        }

        // POST: /Solicitante/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var solicitante = await _context.Solicitantes.FindAsync(id);
            if (solicitante != null)
            {
                _context.Solicitantes.Remove(solicitante);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

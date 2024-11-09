using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T3_Grupo3_Augusto_Alcarras.Models.Datos;


namespace T3_Grupo3_Augusto_Alcarras.Controllers
{
    [Authorize]
    public class LibroController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public LibroController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Libros.ToListAsync());
        }
        [Authorize]
        public IActionResult Crear() => View();

        [HttpPost]

        public async Task<IActionResult> Crear(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }
        [Authorize]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return NotFound();
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null) return NotFound();
            return View(libro);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Libro libro)
        {
            if (id != libro.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }
        [Authorize]
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null) return NotFound();
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null) return NotFound();
            return View(libro);
        }

        [HttpPost, ActionName("Eliminar")]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}

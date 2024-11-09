using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace T3_Grupo3_Augusto_Alcarras.Controllers
{
    [Authorize]
    public class LibrosController : Controller
    {
        public IActionResult Arquitectura()
        {
            // Lógica para obtener los libros de Arquitectura de Software
            return View();
        }

        public IActionResult Diseno()
        {
            // Lógica para obtener los libros de Diseño de Software
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using CalculoSalarios.Models;

namespace CalculoSalarios.Controllers
{
    public class EmpleadoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calcular(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                return View("Resultado", empleado);
            }
            return View("Index");
        }
    }
}

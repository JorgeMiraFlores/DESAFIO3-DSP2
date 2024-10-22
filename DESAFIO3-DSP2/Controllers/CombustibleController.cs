using Microsoft.AspNetCore.Mvc;
using CalculadoraCombustible.Models;

namespace CalculadoraCombustible.Controllers
{
    public class CombustibleController : Controller
    {
        public IActionResult Index()
        {
            return View(new Combustible());
        }

        [HttpPost]
        public IActionResult Calcular(Combustible combustible)
        {
            switch (combustible.Tipo)
            {
                case "Regular":
                    combustible.Precio = 4.05m;
                    break;
                case "Especial":
                    combustible.Precio = 4.25m;
                    break;
                case "Diesel":
                    combustible.Precio = 3.96m;
                    break;
            }

            return View("Index", combustible);
        }
    }
}

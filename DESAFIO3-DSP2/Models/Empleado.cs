using System.ComponentModel.DataAnnotations;
using System.Globalization; // Para manejo correcto de formatos

namespace CalculoSalarios.Models
{
    public class Empleado
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El sueldo es obligatorio.")]
        [Range(1, double.MaxValue, ErrorMessage = "El sueldo debe ser positivo.")]
        public decimal SueldoBase { get; set; }

        // Cálculo del ISSS (7.3%)
        public decimal ISSS => Math.Round(SueldoBase * 0.073m, 2);

        // Cálculo del AFP (5.1%)
        public decimal AFP => Math.Round(SueldoBase * 0.051m, 2);

        // Cálculo de la renta
        public decimal Renta => Math.Round(CalcularRenta(SueldoBase - ISSS - AFP), 2);

        // Cálculo del sueldo neto
        public decimal SueldoNeto => SueldoBase - ISSS - AFP - Renta;

        // Método para calcular la renta según tramos vigentes
        private decimal CalcularRenta(decimal salarioGravable)
        {
            if (salarioGravable <= 472.00m)
                return 0;
            else if (salarioGravable <= 895.24m)
                return (salarioGravable - 472.00m) * 0.10m + 17.67m;
            else if (salarioGravable <= 2038.10m)
                return (salarioGravable - 895.24m) * 0.20m + 60.00m;
            else
                return (salarioGravable - 2038.10m) * 0.30m + 288.57m;
        }
    }
}

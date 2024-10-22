namespace CalculadoraCombustible.Models
{
    public class Combustible
    {
        public string Tipo { get; set; }
        public decimal Precio { get; set; }
        public decimal Galones { get; set; }
        public decimal Total => Precio * Galones;
    }
}

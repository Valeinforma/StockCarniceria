using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }

        public DateTime Fecha { get; set; }

        public int UsuarioId { get; set; }

        public string? Cliente { get; set; }  // Puede ser null
        public bool IsDeleted { get; set; } = false;
        public decimal Precio { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Fecha: {Fecha}, UsuarioId: {UsuarioId}, Cliente: {Cliente}, Precio: {Precio}";
        }
    }
 
}

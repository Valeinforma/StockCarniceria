using Service.Enum;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.Models
{
    public class Venta
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        // --- Claves Foráneas y Propiedades de Navegación de Usuarios ---
        public int? VendedorId { get; set; }
        public Usuarios? Vendedor { get; set; } // Propiedad de navegación (PascalCase)



        public int? ClienteId { get; set; }
        public Usuarios? Cliente { get; set; } // Propiedad de navegación (PascalCase)

        // --- Nombre del Cliente Anónimo (si es necesario) ---
        public string? NombreClienteSinUsuario { get; set; } 

        // --- Relación con los items/productos de la venta ---
        public ICollection<DetalleVenta>? Items { get; set; }

        // --- Propiedades de la Venta ---
        public decimal PrecioTotal { get; set; } // Renombrada para mayor claridad
        public TipoPagoEnum TipoPagoEnum { get; set; } = TipoPagoEnum.Efectivo;
        public bool IsDeleted { get; set; } = false;
    }

}

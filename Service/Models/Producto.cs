using System.Text.Json.Serialization;

namespace Service.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal PrecioUnitario { get; set; } = 0;

        public ICollection<DetalleVenta>? DetallesVenta { get; set; }

        public int Stock { get; set; } = 0;
        public int ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }

        public string Unidad { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;

        public Categoria? Categoria { get; set; }
        public int CategoriaId { get; set; }

        // Relación uno-a-uno con Venta
        public int? VentaId { get; set; }
        public Venta? Venta { get; set; }

        public override string ToString() => Nombre;
    }
}
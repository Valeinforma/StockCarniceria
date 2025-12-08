using System.Text.Json.Serialization;

namespace Service.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal PrecioUnitario { get; set; } = 0;

        [JsonIgnore]
        public ICollection<DetalleVenta>? DetallesVenta { get; set; }

        public int Stock { get; set; } = 0;
        public int ProveedorId { get; set; }
            
        // ✅ SIN [JsonIgnore] - Permitir serialización
        public Proveedor? Proveedor { get; set; }

        public string Unidad { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;

        // ✅ SIN [JsonIgnore] - Permitir serialización
        public Categoria? Categoria { get; set; }

        public int CategoriaId { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
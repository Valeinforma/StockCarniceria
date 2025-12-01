using System.Text.Json.Serialization;
using Service.Enum;

namespace Service.Models
{
    public class Venta
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int? VendedorId { get; set; }
        public Usuario? Vendedor { get; set; }

        public int? ClienteId { get; set; }
        public Usuario? Cliente { get; set; }

        public string? NombreClienteSinUsuario { get; set; }

        [JsonIgnore]
        public ICollection<DetalleVenta>? Items { get; set; }

        public decimal PrecioTotal { get; set; }
        public TipoPagoEnum TipoPagoEnum { get; set; } = TipoPagoEnum.Efectivo;
        public bool IsDeleted { get; set; } = false;
    }
}

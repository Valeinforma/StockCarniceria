using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.Models
{
    public class DetalleCompra
    {
        public int Id { get; set; }
        public int IdDetalleCompra { get; set; }
        public int IdCompra { get; set; }
        public DateTime FechaCompra { get; set; }
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int ProveedorId { get; set; }
        public override string ToString()
        {
            return $"{Id} - {ProductoId} - {Cantidad} - {PrecioUnitario}";
        }
    }

}

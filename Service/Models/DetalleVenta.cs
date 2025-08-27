using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.Models
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int IdDetalleVenta { get; set; }

        public int VentaId { get; set; }

        public int ProductoId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, VentaId: {VentaId}, ProductoId: {ProductoId}, Cantidad: {Cantidad}, PrecioUnitario: {PrecioUnitario}";
        }
    }

}

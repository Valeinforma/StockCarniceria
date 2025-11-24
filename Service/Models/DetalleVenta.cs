using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.Models
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        
        public Venta venta { get; set; } 
        public int VentaId { get; set; }

        public int ProductoId { get; set; }
        public Producto producto { get; set; }

        public bool IsDeleted { get; set; } = false;
        public decimal CantidadProductoVendido { get; set; }


        public decimal PrecioTotalProductoVendido { get; set; } // PrecioUnitario * CantidadProductoVendido

    }

}

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
    }
 
}

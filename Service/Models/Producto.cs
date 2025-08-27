namespace Service.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int ProveedorId { get; set; } 
        public string Nombre { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public string Unidad { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;
        public int CategoriaId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre}, Precio: {Precio}, Stock: {Stock}, Unidad: {Unidad}, ProveedorId: {ProveedorId}, CategoriaId: {CategoriaId}";
        }
    }

}

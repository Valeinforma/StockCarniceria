namespace Service.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public decimal Precio { get; set; } = 0;

        public int Stock { get; set; } = 0;

        public string Unidad { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; } = null!;

        public override string ToString()
        {
            return Nombre;
        }
    }

}

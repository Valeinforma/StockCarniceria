namespace Service.Models
{
    public class Categoria  
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool IsDeleted { get; set; } = false;
        // Relación Uno a Muchos: Una Categoría tiene muchos Productos
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
        public override string ToString()
        {
            return Nombre;
        }
    }
}

using System.Text.Json.Serialization;

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

        // Relacion 1 a 1
        // Aplica [JsonIgnore] aquí para que el serializador no intente
        // cargar recursivamente la Categoría desde el Producto, rompiendo el ciclo.
        [JsonIgnore]
        public Categoria Categoria { get; set; } = null!;
        public int CategoriaId { get; set; }
        
        public override string ToString()
        {
            return Nombre;
        }
    }

}

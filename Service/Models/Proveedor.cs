using System.Text.Json.Serialization;

namespace Service.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;

        [JsonIgnore]
        public ICollection<Producto>? Productos { get; set; } = new List<Producto>();

        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre}";
        }
    }
}

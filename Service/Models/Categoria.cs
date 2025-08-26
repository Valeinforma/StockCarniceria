namespace Service.Models
{
    public class Categoria  
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string categoria { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;

        public override string ToString()
        {
            return Nombre;
        }
    }
}

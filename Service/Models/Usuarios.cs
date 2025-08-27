using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty; // admin, vendedor
        public bool IsDeleted { get; set; } = false;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}

using Service.Enum;
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
        public TipoUsuarioEnum tipoUsuarioEnum { get; set; } = TipoUsuarioEnum.Cliente;
        public bool IsDeleted { get; set; } = false;
       

    }
}

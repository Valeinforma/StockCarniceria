using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.Interfaces
{
    public interface IProductoService : IGenericService<Producto>
    {
        public Task<List<Producto>?> GetProductosPorCategoriaAsync();
        public Task<List<Producto>?> BuscarProductosPorNombreAsync();
    }
}

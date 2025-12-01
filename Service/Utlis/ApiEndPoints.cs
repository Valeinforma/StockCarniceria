using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Utlis
{
    public static class ApiEndPoins
    {
        public static string Categoria { get; set; } = "categorias";
        public static string Usuario { get; set; } = "usuarios";
        public static string DetalleCompra { get; set; } = "detallecompras";
        public static string DetalleVenta { get; set; } = "detalleventa";
        public static string Producto { get; set; } = "productos";
        public static string Proveedor { get; set; } = "proveedores";
        public static string Venta { get; set; } = "ventas";



        public static string GetEndpoint(string name)
        {
            return name switch
            {
                nameof(Categoria) => Categoria,
                nameof(Usuario) => Usuario,
                "Usuarios" => Usuario,
                nameof(DetalleCompra) => DetalleCompra,
                nameof(DetalleVenta) => DetalleVenta,
                nameof(Producto) => Producto,
                nameof(Proveedor) => Proveedor,
                nameof(Venta) => Venta,
                _ => throw new ArgumentException($"Endpoint '{name}' no está definido.")
            };
        }
    }
}

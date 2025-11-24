using Microsoft.EntityFrameworkCore;
using Service.Enum;
using Service.Models;

namespace Backend.DataContext;

public class StockCarniceriaContext : DbContext
{
   public DbSet<Producto> Productos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    public DbSet<DetalleVenta> DetallesVenta { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<DetalleCompra> DetallesCompra { get; set; }


    public StockCarniceriaContext(){}
    public StockCarniceriaContext(DbContextOptions<StockCarniceriaContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Datos Semilla para Categorias
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nombre = "Carnes Rojas", IsDeleted = false },
            new Categoria { Id = 2, Nombre = "Carnes Blancas", IsDeleted = false },
            new Categoria { Id = 3, Nombre = "Embutidos", IsDeleted = false },
            new Categoria { Id = 4, Nombre = "Mariscos", IsDeleted = false }
        );

        // Datos Semilla para Proveedores
        modelBuilder.Entity<Proveedor>().HasData(
            new Proveedor { Id = 1, Nombre = "Ganadería Premium S.A.", IsDeleted = false },
            new Proveedor { Id = 2, Nombre = "Distribuidora de Carnes del Sur", IsDeleted = false },
            new Proveedor { Id = 3, Nombre = "Mariscos Frescos Ltda.", IsDeleted = false },
            new Proveedor { Id = 4, Nombre = "Embutidos Artesanales", IsDeleted = false }
        );

        // Datos Semilla para Usuarios
        modelBuilder.Entity<Usuarios>().HasData(
            new Usuarios
            {
                Id = 1,
                Nombre = "Admin Carnicería",
                Rol = "admin",
                Email = "admin@carniceria.com",
                Password = "hashed_password_admin",
                IsDeleted = false
            },
            new Usuarios
            {
                Id = 2,
                Nombre = "Juan Vendedor",
                Rol = "vendedor",
                Email = "juan@carniceria.com",
                Password = "hashed_password_vendedor",
                IsDeleted = false
            },
            new Usuarios
            {
                Id = 3,
                Nombre = "María Vendedora",
                Rol = "vendedor",
                Email = "maria@carniceria.com",
                Password = "hashed_password_vendedor2",
                IsDeleted = false
            }
        );

        // Datos Semilla para Productos
        modelBuilder.Entity<Producto>().HasData(
            new Producto { Id = 1, Nombre = "Carne de Res - Corte Premium", Precio = 25.50M, Stock = 50, Unidad = "kg", CategoriaId = 1, IsDeleted = false },
            new Producto { Id = 2, Nombre = "Carne de Res - Costilla", Precio = 18.75M, Stock = 35, Unidad = "kg", CategoriaId = 1, IsDeleted = false },
            new Producto { Id = 3, Nombre = "Carne Molida de Res", Precio = 15.99M, Stock = 60, Unidad = "kg", CategoriaId = 1, IsDeleted = false },
            new Producto { Id = 4, Nombre = "Pechuga de Pollo", Precio = 9.50M, Stock = 80, Unidad = "kg", CategoriaId = 2, IsDeleted = false },
            new Producto { Id = 5, Nombre = "Muslo de Pollo", Precio = 7.99M, Stock = 75, Unidad = "kg", CategoriaId = 2, IsDeleted = false },
            new Producto { Id = 6, Nombre = "Filete de Pescado", Precio = 16.50M, Stock = 40, Unidad = "kg", CategoriaId = 2, IsDeleted = false },
            new Producto { Id = 7, Nombre = "Jamón Serrano", Precio = 22.00M, Stock = 30, Unidad = "kg", CategoriaId = 3, IsDeleted = false },
            new Producto { Id = 8, Nombre = "Chorizo Español", Precio = 14.50M, Stock = 25, Unidad = "kg", CategoriaId = 3, IsDeleted = false },
            new Producto { Id = 9, Nombre = "Salchicha Premium", Precio = 12.75M, Stock = 45, Unidad = "kg", CategoriaId = 3, IsDeleted = false },
            new Producto { Id = 10, Nombre = "Camarón Fresco", Precio = 28.00M, Stock = 20, Unidad = "kg", CategoriaId = 4, IsDeleted = false },
            new Producto { Id = 11, Nombre = "Pulpo Gallego", Precio = 32.50M, Stock = 15, Unidad = "kg", CategoriaId = 4, IsDeleted = false },
            new Producto { Id = 12, Nombre = "Mejillones Frescos", Precio = 11.99M, Stock = 50, Unidad = "kg", CategoriaId = 4, IsDeleted = false }
        );

        // Datos Semilla para Ventas
        modelBuilder.Entity<Venta>().HasData(
            new Venta
            {
                Id = 1,
                IdVenta = 1001,
                Fecha = DateTime.Now.AddDays(-7),
                UsuarioId = 2,
                Cliente = "Juan Pérez",
                Precio = 76.50M,
                TipoPagoEnum = TipoPagoEnum.Efectivo,
                IsDeleted = false
            },
            new Venta
            {
                Id = 2,
                IdVenta = 1002,
                Fecha = DateTime.Now.AddDays(-5),
                UsuarioId = 3,
                Cliente = "María García",
                Precio = 57.49M,
                TipoPagoEnum = TipoPagoEnum.TarjetaCredito,
                IsDeleted = false
            },
            new Venta
            {
                Id = 3,
                IdVenta = 1003,
                Fecha = DateTime.Now.AddDays(-2),
                UsuarioId = 2,
                Cliente = "Carlos López",
                Precio = 94.99M,
                TipoPagoEnum = TipoPagoEnum.TarjetaDebito,
                IsDeleted = false
            },
            new Venta
            {
                Id = 4,
                IdVenta = 1004,
                Fecha = DateTime.Now.AddDays(-1),
                UsuarioId = 3,
                Cliente = "Ana Martínez",
                Precio = 45.75M,
                TipoPagoEnum = TipoPagoEnum.TransferenciaBancaria,
                IsDeleted = false
            }
        );

        // Datos Semilla para DetalleVenta
        modelBuilder.Entity<DetalleVenta>().HasData(
            new DetalleVenta { Id = 1, IdDetalleVenta = 1, VentaId = 1, ProductoId = 1, Cantidad = 2, PrecioUnitario = 25.50M, IsDeleted = false },
            new DetalleVenta { Id = 2, IdDetalleVenta = 2, VentaId = 1, ProductoId = 4, Cantidad = 2, PrecioUnitario = 9.50M, IsDeleted = false },
            new DetalleVenta { Id = 3, IdDetalleVenta = 3, VentaId = 2, ProductoId = 3, Cantidad = 1, PrecioUnitario = 15.99M, IsDeleted = false },
            new DetalleVenta { Id = 4, IdDetalleVenta = 4, VentaId = 2, ProductoId = 7, Cantidad = 2, PrecioUnitario = 22.00M, IsDeleted = false },
            new DetalleVenta { Id = 5, IdDetalleVenta = 5, VentaId = 3, ProductoId = 10, Cantidad = 2, PrecioUnitario = 28.00M, IsDeleted = false },
            new DetalleVenta { Id = 6, IdDetalleVenta = 6, VentaId = 3, ProductoId = 5, Cantidad = 3, PrecioUnitario = 7.99M, IsDeleted = false },
            new DetalleVenta { Id = 7, IdDetalleVenta = 7, VentaId = 4, ProductoId = 8, Cantidad = 1.5M, PrecioUnitario = 14.50M, IsDeleted = false },
            new DetalleVenta { Id = 8, IdDetalleVenta = 8, VentaId = 4, ProductoId = 12, Cantidad = 2, PrecioUnitario = 11.99M, IsDeleted = false }
        );

        // Datos Semilla para DetalleCompra
        modelBuilder.Entity<DetalleCompra>().HasData(
            new DetalleCompra { Id = 1, IdDetalleCompra = 1, IdCompra = 5001, FechaCompra = DateTime.Now.AddDays(-30), ProductoId = 1, Cantidad = 100, PrecioUnitario = 18.00M, ProveedorId = 1, IsDeleted = false },
            new DetalleCompra { Id = 2, IdDetalleCompra = 2, IdCompra = 5002, FechaCompra = DateTime.Now.AddDays(-28), ProductoId = 4, Cantidad = 150, PrecioUnitario = 6.50M, ProveedorId = 1, IsDeleted = false },
            new DetalleCompra { Id = 3, IdDetalleCompra = 3, IdCompra = 5003, FechaCompra = DateTime.Now.AddDays(-25), ProductoId = 7, Cantidad = 80, PrecioUnitario = 16.00M, ProveedorId = 4, IsDeleted = false },
            new DetalleCompra { Id = 4, IdDetalleCompra = 4, IdCompra = 5004, FechaCompra = DateTime.Now.AddDays(-20), ProductoId = 10, Cantidad = 50, PrecioUnitario = 20.00M, ProveedorId = 3, IsDeleted = false },
            new DetalleCompra { Id = 5, IdDetalleCompra = 5, IdCompra = 5005, FechaCompra = DateTime.Now.AddDays(-15), ProductoId = 3, Cantidad = 120, PrecioUnitario = 11.50M, ProveedorId = 2, IsDeleted = false },
            new DetalleCompra { Id = 6, IdDetalleCompra = 6, IdCompra = 5006, FechaCompra = DateTime.Now.AddDays(-10), ProductoId = 12, Cantidad = 100, PrecioUnitario = 8.50M, ProveedorId = 3, IsDeleted = false }
        );





        // Configuramos las querys para que no devuelvan los elementos eliminados
        modelBuilder.Entity<Producto>().HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<Categoria>().HasQueryFilter(c => !c.IsDeleted);
        modelBuilder.Entity<Proveedor>().HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<Venta>().HasQueryFilter(v => !v.IsDeleted);
        modelBuilder.Entity<DetalleVenta>().HasQueryFilter(dv => !dv.IsDeleted);
        modelBuilder.Entity<Usuarios>().HasQueryFilter(u => !u.IsDeleted);
        modelBuilder.Entity<DetalleCompra>().HasQueryFilter(dc => !dc.IsDeleted);

    }
}

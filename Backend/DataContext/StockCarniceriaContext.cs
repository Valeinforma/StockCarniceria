using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
        //datos semila de los modelos
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nombre = "Carnes Rojas" },
            new Categoria { Id = 2, Nombre = "Carnes Blancas" },
            new Categoria { Id = 3, Nombre = "Embutidos" }
        );
        modelBuilder.Entity<Proveedor>().HasData(
            new Proveedor { Id = 1, Nombre = "Proveedor A" },
            new Proveedor { Id = 2, Nombre = "Proveedor B" }
        );
        //datos semilla de usuarios
        modelBuilder.Entity<Usuarios>().HasData(
            new Usuarios
            {
                Id = 1,
                Nombre = "Martin",
                Rol = "admin",
                IsDeleted = false,
                Password = "admin123", // Considera hashear en producción
                Email = "admin@carniceria.com"
            },
            new Usuarios
            {
                Id = 2,
                Nombre = "Pepe",
                Rol = "vendedor",
                IsDeleted = false,
                Password = "vendedor123",
                Email = "vendedor1@carniceria.com"
            }
        );
        //datos semilla de productos
        modelBuilder.Entity<Producto>().HasData(
            new Producto { Id = 1, Nombre = "Bife de Chorizo", CategoriaId = 1, ProveedorId = 1, Precio = 1500.00m, Stock = 50 },
            new Producto { Id = 2, Nombre = "Pechuga de Pollo", CategoriaId = 2, ProveedorId = 2, Precio = 800.00m, Stock = 100 },
            new Producto { Id = 3, Nombre = "Chorizo", CategoriaId = 3, ProveedorId = 1, Precio = 400.00m, Stock = 200 }
        );
        //datos semilla de ventas
        modelBuilder.Entity<Venta>().HasData(
            new Venta { Id = 1, Fecha = DateTime.Now, Precio = 3000.00m, UsuarioId = 2 },
            new Venta { Id = 2, Fecha = DateTime.Now, Precio = 1500.00m, UsuarioId = 2 }
        );
        //datos semilla de detalles de detalles de venta
        modelBuilder.Entity<DetalleVenta>().HasData(
            new DetalleVenta { Id = 1, VentaId = 1, ProductoId = 1, Cantidad = 2, PrecioUnitario = 1500.00m },
            new DetalleVenta { Id = 2, VentaId = 2, ProductoId = 2, Cantidad = 1, PrecioUnitario = 800.00m }
        );
        //datos semilla de detalles de compra
        modelBuilder.Entity<DetalleCompra>().HasData(
            new DetalleCompra { Id = 1, ProductoId = 1, Cantidad = 20, PrecioUnitario = 1200.00m, FechaCompra = DateTime.Now, ProveedorId = 1 },
            new DetalleCompra { Id = 2, ProductoId = 2, Cantidad = 50, PrecioUnitario = 700.00m, FechaCompra = DateTime.Now, ProveedorId = 2 }
        );
       

        modelBuilder.Entity<Producto>().HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<Usuarios>().HasQueryFilter(u => !u.IsDeleted);
        modelBuilder.Entity<DetalleCompra>().HasQueryFilter(dc => !dc.IsDeleted);
        modelBuilder.Entity<DetalleVenta>().HasQueryFilter(dv => !dv.IsDeleted);
        modelBuilder.Entity<Venta>().HasQueryFilter(v => !v.IsDeleted);
        modelBuilder.Entity<Proveedor>().HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<Categoria>().HasQueryFilter(c => !c.IsDeleted);
    }
}

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
        // ==========================
        // Categorías
        // ==========================
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nombre = "Vacuno" },
            new Categoria { Id = 2, Nombre = "Aves" },
            new Categoria { Id = 3, Nombre = "Lácteos" },
            new Categoria { Id = 4, Nombre = "Bebidas" }
        );

        // ==========================
        // Proveedores
        // ==========================
        modelBuilder.Entity<Proveedor>().HasData(
            new Proveedor { Id = 1, Nombre = "Frigorífico Patagonia" },
            new Proveedor { Id = 2, Nombre = "Avícola San Juan" },
            new Proveedor { Id = 3, Nombre = "Distribuidora Láctea SRL" }
        );

        // ==========================
        // Usuarios
        // ==========================
        modelBuilder.Entity<Usuarios>().HasData(
            new Usuarios
            {
                Id = 1,
                Nombre = "Sofia",
                Rol = "admin",
                IsDeleted = false,
                Password = "sofiaAdmin2025", // en prod se recomienda hashear
                Email = "admin@tienda.com"
            },
            new Usuarios
            {
                Id = 2,
                Nombre = "Carlos",
                Rol = "vendedor",
                IsDeleted = false,
                Password = "carlosV123",
                Email = "carlos@tienda.com"
            },
            new Usuarios
            {
                Id = 3,
                Nombre = "Lucia",
                Rol = "vendedor",
                IsDeleted = false,
                Password = "luciaV123",
                Email = "lucia@tienda.com"
            }
        );

        // ==========================
        // Productos
        // ==========================
        modelBuilder.Entity<Producto>().HasData(
            new Producto { Id = 1, Nombre = "Asado", Precio = 2500.00m, Stock = 15, Unidad = "kg", ProveedorId = 1, CategoriaId = 1 },
            new Producto { Id = 2, Nombre = "Suprema de Pollo", Precio = 1200.00m, Stock = 40, Unidad = "kg", ProveedorId = 2, CategoriaId = 2 },
            new Producto { Id = 3, Nombre = "Queso Muzzarella", Precio = 1800.00m, Stock = 20, Unidad = "kg", ProveedorId = 3, CategoriaId = 3 },
            new Producto { Id = 4, Nombre = "Leche Entera", Precio = 900.00m, Stock = 50, Unidad = "litro", ProveedorId = 3, CategoriaId = 3 },
            new Producto { Id = 5, Nombre = "Gaseosa Cola 2L", Precio = 1500.00m, Stock = 35, Unidad = "botella", ProveedorId = 2, CategoriaId = 4 }
        );

        // ==========================
        // Ventas
        // ==========================
        modelBuilder.Entity<Venta>().HasData(
            new Venta { Id = 1, Fecha = DateTime.Now, UsuarioId = 2, Cliente = "Pedro López", Precio = 5000.00m, TipoPagoEnum = Service.Enum.TipoPagoEnum.Efectivo },
            new Venta { Id = 2, Fecha = DateTime.Now, UsuarioId = 3, Cliente = "Laura Fernández", Precio = 2700.00m, TipoPagoEnum = Service.Enum.TipoPagoEnum.TarjetaCredito }
        );

        // ==========================
        // Detalles de Venta
        // ==========================
        modelBuilder.Entity<DetalleVenta>().HasData(
            new DetalleVenta { Id = 1, VentaId = 1, ProductoId = 1, Cantidad = 2, PrecioUnitario = 2500.00m }, // 2kg Asado
            new DetalleVenta { Id = 2, VentaId = 1, ProductoId = 5, Cantidad = 1, PrecioUnitario = 1500.00m }, // 1 Gaseosa
            new DetalleVenta { Id = 3, VentaId = 2, ProductoId = 2, Cantidad = 1, PrecioUnitario = 1200.00m }, // 1kg Suprema
            new DetalleVenta { Id = 4, VentaId = 2, ProductoId = 4, Cantidad = 2, PrecioUnitario = 900.00m }   // 2 Leches
        );

        // ==========================
        // Detalles de Compra
        // ==========================
        modelBuilder.Entity<DetalleCompra>().HasData(
            new DetalleCompra { Id = 1, ProductoId = 1, Cantidad = 30, PrecioUnitario = 2000.00m, FechaCompra = DateTime.Now, ProveedorId = 1 },
            new DetalleCompra { Id = 2, ProductoId = 2, Cantidad = 60, PrecioUnitario = 1000.00m, FechaCompra = DateTime.Now, ProveedorId = 2 },
            new DetalleCompra { Id = 3, ProductoId = 3, Cantidad = 25, PrecioUnitario = 1500.00m, FechaCompra = DateTime.Now, ProveedorId = 3 },
            new DetalleCompra { Id = 4, ProductoId = 5, Cantidad = 50, PrecioUnitario = 1200.00m, FechaCompra = DateTime.Now, ProveedorId = 2 }
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

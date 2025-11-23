using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
        // Seed data for Categoria
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nombre = "Carnes Rojas", IsDeleted = false },
            new Categoria { Id = 2, Nombre = "Carnes Blancas", IsDeleted = false }
        );

        // Seed data for Producto
        modelBuilder.Entity<Producto>().HasData(
            new Producto { Id = 1, Nombre = "Bife de Chorizo", Precio = 1500, Stock = 50, Unidad = "kg", IsDeleted = false, CategoriaId = 1 },
            new Producto { Id = 2, Nombre = "Pechuga de Pollo", Precio = 800, Stock = 100, Unidad = "kg", IsDeleted = false, CategoriaId = 2 }
        );

        // Seed data for Proveedor
        modelBuilder.Entity<Proveedor>().HasData(
            new Proveedor { Id = 1, Nombre = "Proveedor A", IsDeleted = false },
            new Proveedor { Id = 2, Nombre = "Proveedor B", IsDeleted = false }
        );

        // Seed data for Usuarios
        modelBuilder.Entity<Usuarios>().HasData(
            new Usuarios { Id = 1, Nombre = "Admin", Rol = "admin", Password = "admin123", Email = "admin@example.com", IsDeleted = false },
            new Usuarios { Id = 2, Nombre = "Vendedor", Rol = "vendedor", Password = "vendedor123", Email = "vendedor@example.com", IsDeleted = false }
        );

        // Seed data for Venta
        modelBuilder.Entity<Venta>().HasData(
            new Venta { Id = 1, IdVenta = 1001, Fecha = DateTime.Now, UsuarioId = 1, Cliente = "Cliente A", IsDeleted = false, Precio = 3000, TipoPagoEnum = TipoPagoEnum.Efectivo }
        );

        // Seed data for DetalleVenta
        modelBuilder.Entity<DetalleVenta>().HasData(
            new DetalleVenta { Id = 1, IdDetalleVenta = 2001, VentaId = 1, ProductoId = 1, Cantidad = 2, PrecioUnitario = 1500, IsDeleted = false }
        );

        // Seed data for DetalleCompra
        modelBuilder.Entity<DetalleCompra>().HasData(
            new DetalleCompra { Id = 1, IdDetalleCompra = 3001, IdCompra = 1, FechaCompra = DateTime.Now, ProductoId = 1, Cantidad = 20, PrecioUnitario = 1400, ProveedorId = 1, IsDeleted = false }
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

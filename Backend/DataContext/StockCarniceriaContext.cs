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
    public DbSet<Usuario> Usuarios { get; set; }
    



    public StockCarniceriaContext(){}
    public StockCarniceriaContext(DbContextOptions<StockCarniceriaContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Query Filters para eliminar lógicamente (PRIMERO)
        modelBuilder.Entity<Producto>().HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<Categoria>().HasQueryFilter(c => !c.IsDeleted);
        modelBuilder.Entity<Proveedor>().HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<Venta>().HasQueryFilter(v => !v.IsDeleted);
        modelBuilder.Entity<DetalleVenta>().HasQueryFilter(dv => !dv.IsDeleted);
        modelBuilder.Entity<Usuario>().HasQueryFilter(u => !u.IsDeleted);

        // Configurar solo las relaciones críticas
        // Relación: Categoria -> Productos (1:N)
        modelBuilder.Entity<Producto>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.Productos)
            .HasForeignKey(p => p.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación: Proveedor -> Productos (1:N)
        modelBuilder.Entity<Producto>()
            .HasOne(p => p.Proveedor)
            .WithMany(pr => pr.Productos)
            .HasForeignKey(p => p.ProveedorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Datos Semilla para Usuarios
        modelBuilder.Entity<Usuario>().HasData(
            new Usuario { Id = 1, Nombre = "Carlos Mendez", tipoUsuarioEnum = TipoUsuarioEnum.Vendedor, IsDeleted = false },
            new Usuario { Id = 2, Nombre = "Ana González", tipoUsuarioEnum = TipoUsuarioEnum.Vendedor, IsDeleted = false },
            new Usuario { Id = 3, Nombre = "Juan Pérez", tipoUsuarioEnum = TipoUsuarioEnum.Cliente, IsDeleted = false },
            new Usuario { Id = 4, Nombre = "María García", tipoUsuarioEnum = TipoUsuarioEnum.Cliente, IsDeleted = false },
            new Usuario { Id = 5, Nombre = "Roberto López", tipoUsuarioEnum = TipoUsuarioEnum.Cliente, IsDeleted = false },
            new Usuario { Id = 6, Nombre = "Sofía Martínez", tipoUsuarioEnum = TipoUsuarioEnum.Vendedor, IsDeleted = false }
        );

        // Datos Semilla para Categorias
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nombre = "Carnes Rojas", IsDeleted = false },
            new Categoria { Id = 2, Nombre = "Aves y Pescados", IsDeleted = false },
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

        // Datos Semilla para Productos
        modelBuilder.Entity<Producto>().HasData(
            new Producto { Id = 1, Nombre = "Carne de Res - Corte Premium", PrecioUnitario = 25.50M, Stock = 50, Unidad = "kg", CategoriaId = 1, ProveedorId = 1, IsDeleted = false },
            new Producto { Id = 2, Nombre = "Carne de Res - Costilla", PrecioUnitario = 18.75M, Stock = 35, Unidad = "kg", CategoriaId = 1, ProveedorId = 1, IsDeleted = false },
            new Producto { Id = 3, Nombre = "Carne Molida de Res", PrecioUnitario = 15.99M, Stock = 60, Unidad = "kg", CategoriaId = 1, ProveedorId = 2, IsDeleted = false },
            new Producto { Id = 4, Nombre = "Pechuga de Pollo", PrecioUnitario = 9.50M, Stock = 80, Unidad = "kg", CategoriaId = 2, ProveedorId = 1, IsDeleted = false },
            new Producto { Id = 5, Nombre = "Muslo de Pollo", PrecioUnitario = 7.99M, Stock = 75, Unidad = "kg", CategoriaId = 2, ProveedorId = 1, IsDeleted = false },
            new Producto { Id = 6, Nombre = "Filete de Pescado", PrecioUnitario = 16.50M, Stock = 40, Unidad = "kg", CategoriaId = 2, ProveedorId = 2, IsDeleted = false },
            new Producto { Id = 7, Nombre = "Jamón Serrano", PrecioUnitario = 22.00M, Stock = 30, Unidad = "kg", CategoriaId = 3, ProveedorId = 4, IsDeleted = false },
            new Producto { Id = 8, Nombre = "Chorizo Español", PrecioUnitario = 14.50M, Stock = 25, Unidad = "kg", CategoriaId = 3, ProveedorId = 4, IsDeleted = false },
            new Producto { Id = 9, Nombre = "Salchicha Premium", PrecioUnitario = 12.75M, Stock = 45, Unidad = "kg", CategoriaId = 3, ProveedorId = 4, IsDeleted = false },
            new Producto { Id = 10, Nombre = "Camarón Fresco", PrecioUnitario = 28.00M, Stock = 20, Unidad = "kg", CategoriaId = 4, ProveedorId = 3, IsDeleted = false },
            new Producto { Id = 11, Nombre = "Pulpo Gallego", PrecioUnitario = 32.50M, Stock = 15, Unidad = "kg", CategoriaId = 4, ProveedorId = 3, IsDeleted = false },
            new Producto { Id = 12, Nombre = "Mejillones Frescos", PrecioUnitario = 11.99M, Stock = 50, Unidad = "kg", CategoriaId = 4, ProveedorId = 3, IsDeleted = false }
        );

        // Datos Semilla para Ventas
        modelBuilder.Entity<Venta>().HasData(
            new Venta { Id = 1, Fecha = DateTime.Now.AddDays(-7), VendedorId = 1, ClienteId = 3, PrecioTotal = 76.50M, TipoPagoEnum = TipoPagoEnum.Efectivo, IsDeleted = false },
            new Venta { Id = 2, Fecha = DateTime.Now.AddDays(-5), VendedorId = 2, ClienteId = 4, PrecioTotal = 57.49M, TipoPagoEnum = TipoPagoEnum.TarjetaCredito, IsDeleted = false },
            new Venta { Id = 3, Fecha = DateTime.Now.AddDays(-2), VendedorId = 1, ClienteId = 5, PrecioTotal = 94.99M, TipoPagoEnum = TipoPagoEnum.TarjetaDebito, IsDeleted = false },
            new Venta { Id = 4, Fecha = DateTime.Now.AddDays(-1), VendedorId = 2, NombreClienteSinUsuario = "Cliente Anónimo", PrecioTotal = 45.75M, TipoPagoEnum = TipoPagoEnum.Transferencia, IsDeleted = false }
        );

        // Datos Semilla para DetalleVenta
        modelBuilder.Entity<DetalleVenta>().HasData(
            new DetalleVenta { Id = 1, VentaId = 1, ProductoId = 1, CantidadProductoVendido = 2, PrecioTotalProductoVendido = 51.00M, IsDeleted = false },
            new DetalleVenta { Id = 2, VentaId = 1, ProductoId = 4, CantidadProductoVendido = 2.5M, PrecioTotalProductoVendido = 23.75M, IsDeleted = false },
            new DetalleVenta { Id = 3, VentaId = 2, ProductoId = 3, CantidadProductoVendido = 1, PrecioTotalProductoVendido = 15.99M, IsDeleted = false },
            new DetalleVenta { Id = 4, VentaId = 2, ProductoId = 7, CantidadProductoVendido = 1.5M, PrecioTotalProductoVendido = 33.00M, IsDeleted = false },
            new DetalleVenta { Id = 5, VentaId = 3, ProductoId = 10, CantidadProductoVendido = 2, PrecioTotalProductoVendido = 56.00M, IsDeleted = false },
            new DetalleVenta { Id = 6, VentaId = 3, ProductoId = 5, CantidadProductoVendido = 3, PrecioTotalProductoVendido = 23.97M, IsDeleted = false },
            new DetalleVenta { Id = 7, VentaId = 4, ProductoId = 8, CantidadProductoVendido = 1, PrecioTotalProductoVendido = 14.50M, IsDeleted = false },
            new DetalleVenta { Id = 8, VentaId = 4, ProductoId = 12, CantidadProductoVendido = 2, PrecioTotalProductoVendido = 23.98M, IsDeleted = false }
        );
    }
}

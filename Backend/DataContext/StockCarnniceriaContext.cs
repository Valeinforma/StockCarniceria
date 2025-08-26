using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Service.Models;

namespace Backend.DataContext;

public class StockCarnniceriaContext : DbContext
{
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public StockCarnniceriaContext(){}
    public StockCarnniceriaContext(DbContextOptions<StockCarnniceriaContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        //cargamos las categorias de la carne 
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nombre = "Vacuno", IsDeleted = false },
            new Categoria { Id = 2, Nombre = "Cerdo", IsDeleted = false },
            new Categoria { Id = 3, Nombre = "Pollo", IsDeleted = false },
            new Categoria { Id = 4, Nombre = "Cordero", IsDeleted = false }
        );

        //cargamos un usuario para stock de carne 
        modelBuilder.Entity<Usuarios>().HasData(
            new Usuarios
            {
                Id = 1,
                Nombre = "admin",
                Email = "admin@carniceria.com",
                Password = "admin123", // Considera encriptar la contraseña en producción
                IsDeleted = false
            }
        );
        //cargamos un usuario para stock de carne 


        modelBuilder.Entity<Usuarios>().HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<Categoria>().HasQueryFilter(p => !p.IsDeleted);
    }
}

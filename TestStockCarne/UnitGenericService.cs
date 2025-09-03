using Service.Models;
using Service.Services;

namespace TestStockCarne
{
    public class UnitTestGenericService
    {
        [Fact]
        public async void TestGetAllCategoria()
        {
            // Arrange
            var service = new GenericService<Categoria>();
            // Act
            var result = await service.GetAllAsync(null);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Categoria>>(result);
            Assert.True(result.Count > 0);
            foreach (var item in result)
            {
                //imprimimos las capacitaciones
                Console.WriteLine($"Id: {item.Id}, Nombre: {item.Nombre}");
            }


        }
        [Fact]
        public async void TestGetAlDetalleCompra()
        {
            // Arrange
            var service = new GenericService<DetalleCompra>();
            // Act
            var result = await service.GetAllAsync(null);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<DetalleCompra>>(result);
            Assert.True(result.Count > 0);
            foreach (var item in result)
            {
                //imprimimos las capacitaciones
                Console.WriteLine($"Id: {item.Id}, Cantidad: {item.IdDetalleCompra}");
            }


        }
        [Fact]
        public async void TestGetAllUsuario()
        {
            // Arrange
            var service = new GenericService<Usuarios>();
            // Act
            var result = await service.GetAllAsync(null);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Usuarios>>(result);
            Assert.True(result.Count > 0);
            foreach (var item in result)
            {
                //imprimimos las capacitaciones
                Console.WriteLine($"Id: {item.Id}, Nombre: {item.Nombre},{item.Rol} ");
            }


        }
        [Fact]
        public async void TestGetAllDetalleVenta()
        {
            // Arrange
            var service = new GenericService<DetalleVenta>();
            // Act
            var result = await service.GetAllAsync(null);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<DetalleVenta>>(result);
            Assert.True(result.Count > 0);
            foreach (var item in result)
            {
                //imprimimos las capacitaciones
                Console.WriteLine($"Id: {item.Id}, Nombre: {item.IdDetalleVenta}");
            }


        }
        [Fact]
        public async void TestGetAllProducto()
        {
            // Arrange
            var service = new GenericService<Producto>();
            // Act
            var result = await service.GetAllAsync(null);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Producto>>(result);
            Assert.True(result.Count > 0);
            foreach (var item in result)
            {
                //imprimimos las capacitaciones
                Console.WriteLine($"Id: {item.Id}, Productoid: {item.ProveedorId}");
            }


        }

        [Fact]
        public async void TestGetByIdProveedor()
        {
            // Arrange
            var service = new GenericService<Proveedor>();
            int idToTest = 1; // Cambia este valor según el ID que quieras probar
            // Act
            var result = await service.GetByIdAsync(idToTest);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<Proveedor>(result);
            Assert.Equal(idToTest, result.Id);
            Assert.Equal("Público en general", result.Nombre); // Cambia este valor según el nombre esperado
            Console.WriteLine($"Id: {result.Id}, Nombre: {result.Nombre}");
        }

        [Fact] // Forma en que xUnite identifique que lo que vas a poner es un test

        public async void TestDeleteProveedor()
        {
            // Arrange
            var service = new GenericService<Categoria>();
            int idToDelete = 2; // Asumiendo que este ID existe en la base de datos
                                // Act
            var result = await service.DeleteAsync(idToDelete);
            // Assert
            Assert.True(result);
            Console.WriteLine($"TipoInscripcion con Id {idToDelete} eliminada exitosamente.");
        }

        [Fact]
        public async void TestAddTipoInscripcion()
        {
            // Arrange
            var service = new GenericService<DetalleCompra>();
            var DetalleCompra = new DetalleCompra
            {
               Cantidad = 10,
            };
            // Act
            var result = await service.AddAsync(DetalleCompra);
            // Assert
            Assert.NotNull(result);
            Assert.IsType<DetalleCompra>(result);
            Assert.Equal(DetalleCompra.Cantidad, result.Cantidad);
            Console.WriteLine($"TipoInscripcion agregado con Id: {result.Id}, Nombre: {result.Cantidad}");


        }
        [Fact]

        public async void TestDeleteProducto()
        {

            // Arrange
            var service = new GenericService<Producto>();
            int idToDelete = 3; // Asumiendo que este ID existe en la base de datos
                                // Act
            var result = await service.DeleteAsync(idToDelete);
            // Assert
            Assert.True(result);
            Console.WriteLine($"TipoInscripcion con Id {idToDelete} eliminada exitosamente.");
        }


        [Fact]
        public async void TestUpdateProveedor()
        {
            //Arrange
            var service = new GenericService<Proveedor>();
            var Proveedor = new Proveedor()
            {
                Id = 2,
                Nombre = "docente instituto"
            };
            //action
            var result = await service.UpdateAsync(Proveedor);
            // Assert
            Assert.NotNull(result);
            Assert.True(result);




        }

        [Fact]

        public async void TestRestoreUsuario()
        {
            // Arrange
            var service = new GenericService<Usuarios>();
            int idToRestore = 3; // Asumiendo que este ID existe en la base de datos
                                 // Act
            var result = await service.RestoreAsync(idToRestore);
            // Assert
            Assert.True(result);
            Console.WriteLine($"Capacitacion con Id {idToRestore} restaurada exitosamente.");
        }

    }
}
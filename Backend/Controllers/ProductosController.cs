using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DataContext;
using Service.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly StockCarniceriaContext _context;

        public ProductosController(StockCarniceriaContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos([FromQuery] string? filter = null)
        {
            if (_context.Productos == null)
            {
                return StatusCode(500, "El conjunto de entidades 'Productos' no está disponible.");
            }

            try
            {
                var query = _context.Productos
                  .Include(p => p.Categoria)
                  .Include(p => p.Proveedor)
                  .Include(p => p.DetallesVenta)
                  .Where(p => !p.IsDeleted)
                  .AsNoTracking()
                  .AsQueryable();

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    var lowerFilter = filter.Trim().ToLower();
                    query = query.Where(p => p.Nombre.ToLower().Contains(lowerFilter));
                }

                var productos = await query.ToListAsync();

                if (!productos.Any())
                {
                    return NotFound("No se encontraron productos activos que coincidan con los criterios.");
                }

                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al obtener productos: {ex.Message}");
            }
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            if (_context.Productos == null)
            {
                return NotFound();
            }

            try
            {
                var producto = await _context.Productos
                  .Include(p => p.Categoria)
                  .Include(p => p.Proveedor)
                  .AsNoTracking()
                  .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

                if (producto == null)
                {
                    return NotFound($"Producto con ID {id} no encontrado o está eliminado.");
                }

                return Ok(producto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT: api/Productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest("El ID de la ruta no coincide con el ID del producto.");
            }

            try
            {
                // Validar que las claves foráneas sean válidas
                if (producto.CategoriaId <= 0)
                {
                    return BadRequest("CategoriaId debe ser mayor a 0");
                }

                if (producto.ProveedorId <= 0)
                {
                    return BadRequest("ProveedorId debe ser mayor a 0");
                }

                // Verificar que la categoría exista
                var categoriaExiste = await _context.Categorias.AnyAsync(c => c.Id == producto.CategoriaId && !c.IsDeleted);
                if (!categoriaExiste)
                {
                    return BadRequest($"La categoría con ID {producto.CategoriaId} no existe.");
                }

                // Verificar que el proveedor exista
                var proveedorExiste = await _context.Proveedores.AnyAsync(p => p.Id == producto.ProveedorId && !p.IsDeleted);
                if (!proveedorExiste)
                {
                    return BadRequest($"El proveedor con ID {producto.ProveedorId} no existe.");
                }

                // Obtener el producto existente de la BD
                var productoExistente = await _context.Productos.FindAsync(id);
                if (productoExistente == null)
                {
                    return NotFound($"Producto con ID {id} no encontrado.");
                }

                // Actualizar solo los campos necesarios
                productoExistente.Nombre = producto.Nombre;
                productoExistente.PrecioUnitario = producto.PrecioUnitario;
                productoExistente.Stock = producto.Stock;
                productoExistente.Unidad = producto.Unidad;
                productoExistente.CategoriaId = producto.CategoriaId;
                productoExistente.ProveedorId = producto.ProveedorId;

                _context.Entry(productoExistente).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                // Recargar el producto actualizado con sus relaciones para devolverlo
                var productoActualizado = await _context.Productos
                    .AsNoTracking()
                    .Include(p => p.Categoria)
                    .Include(p => p.Proveedor)
                    .FirstOrDefaultAsync(p => p.Id == id);

                return Ok(productoActualizado);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }
                throw;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al actualizar: {ex.Message}");
            }
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            // *** CORRECCIÓN DE VALIDACIÓN 2/2: Ignorar propiedades de navegación en la validación del ModelState ***
            ModelState.Remove(nameof(Producto.Categoria));
            ModelState.Remove(nameof(Producto.Proveedor));

            if (_context.Productos == null)
            {
                return Problem("El conjunto de entidades 'Productos' es nulo.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Validar que la categoría exista
                if (producto.CategoriaId <= 0)
                {
                    return BadRequest("CategoriaId debe ser mayor a 0");
                }

                var categoriaExiste = await _context.Categorias.AnyAsync(c => c.Id == producto.CategoriaId && !c.IsDeleted);
                if (!categoriaExiste)
                {
                    return BadRequest($"La categoría con ID {producto.CategoriaId} no existe.");
                }

                // Validar que el proveedor exista
                if (producto.ProveedorId <= 0)
                {
                    return BadRequest("ProveedorId debe ser mayor a 0");
                }

                var proveedorExiste = await _context.Proveedores.AnyAsync(p => p.Id == producto.ProveedorId && !p.IsDeleted);
                if (!proveedorExiste)
                {
                    return BadRequest($"El proveedor con ID {producto.ProveedorId} no existe.");
                }

                // Limpiar referencias de navegación antes de agregar
                producto.Categoria = null;
                producto.Proveedor = null;
                producto.DetallesVenta = null;
                producto.IsDeleted = false;

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                // Obtener el ID del producto recién creado
                int productoId = producto.Id;

                // Recargar el producto con sus relaciones en una nueva consulta
                var productoCreado = await _context.Productos
                    .AsNoTracking()
                    .Include(p => p.Categoria)
                    .Include(p => p.Proveedor)
                    .FirstOrDefaultAsync(p => p.Id == productoId);

                return CreatedAtAction(nameof(GetProducto), new { id = productoId }, productoCreado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al crear: {ex.Message} - {ex.InnerException?.Message}");
            }
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            try
            {
                var producto = await _context.Productos.FindAsync(id);

                if (producto == null)
                {
                    return NotFound();
                }

                if (producto.IsDeleted)
                {
                    return BadRequest("El producto ya se encuentra eliminado lógicamente.");
                }

                producto.IsDeleted = true;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al eliminar: {ex.Message}");
            }
        }

        // PUT: api/Productos/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreProducto(int id)
        {
            try
            {
                var producto = await _context.Productos
                  .IgnoreQueryFilters()
                  .FirstOrDefaultAsync(p => p.Id == id);

                if (producto == null)
                {
                    return NotFound($"Producto con ID {id} no encontrado.");
                }

                if (!producto.IsDeleted)
                {
                    return BadRequest("El producto no se encuentra eliminado.");
                }

                producto.IsDeleted = false;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al restaurar: {ex.Message}");
            }
        }

        // GET: api/Productos/deleteds
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosDeleteds()
        {
            var eliminados = await _context.Productos
              .IgnoreQueryFilters()
              .Include(p => p.Categoria)
              .Include(p => p.Proveedor)
              .Where(p => p.IsDeleted)
              .AsNoTracking()
              .ToListAsync();

            if (!eliminados.Any())
            {
                return NotFound("No hay productos eliminados.");
            }

            return Ok(eliminados);
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
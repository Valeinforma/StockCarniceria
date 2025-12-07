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

            // *** CORRECCIÓN DE VALIDACIÓN 1/2: Ignorar propiedades de navegación en la validación del ModelState ***
            // Esto previene el error HTTP 400 si las propiedades de navegación vienen nulas
            // pero el validador intenta validarlas.
            ModelState.Remove(nameof(Producto.Categoria));
            ModelState.Remove(nameof(Producto.Proveedor));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // *****************************************************************************************************

            // *** LÓGICA DE ATTACH PARA UPDATE (Similar al POST para seguridad) ***
            // Esto es crucial para el PUT, ya que las entidades relacionadas deben ser rastreadas
            // como existentes antes de modificar el producto.

            // 1. Adjuntar Proveedor (si el objeto no es null)
            if (producto.Proveedor != null)
            {
                // Adjuntamos la entidad existente y la marcamos como no modificada
                _context.Entry(producto.Proveedor).State = EntityState.Unchanged;
            }

            // 2. Adjuntar Categoría (si el objeto no es null)
            if (producto.Categoria != null)
            {
                // Adjuntamos la entidad existente y la marcamos como no modificada
                _context.Entry(producto.Categoria).State = EntityState.Unchanged;
            }

            // *******************************************************************

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            return NoContent();
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            // *** CORRECCIÓN DE VALIDACIÓN 2/2: Ignorar propiedades de navegación en la validación del ModelState ***
            // Esto es necesario porque el validador de ASP.NET Core intenta validar las propiedades anidadas 
            // (e.g., Categoria.Nombre), lo que causa un error 400 si el objeto Categoria/proveedor es nulo.
            ModelState.Remove(nameof(Producto.Categoria));
            ModelState.Remove(nameof(Producto.Proveedor));

            if (_context.Productos == null)
            {
                return Problem("El conjunto de entidades 'Productos' es nulo.");
            }

            // La validación ahora debe ocurrir después de quitar las claves no deseadas.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // *** LÓGICA DE ATTACH PARA CREACIÓN ***
                // Si el cliente envía los objetos de navegación completos, esta lógica
                // asegura que EF Core solo use el ID para la clave foránea, sin intentar
                // crear un Proveedor o Categoría duplicado.

                // 1. Adjuntar Proveedor
                if (producto.Proveedor != null)
                {
                    _context.Entry(producto.Proveedor).State = EntityState.Unchanged;
                }

                // 2. Adjuntar Categoría
                if (producto.Categoria != null)
                {
                    _context.Entry(producto.Categoria).State = EntityState.Unchanged;
                }
                // *** FIN DE LA LÓGICA DE ATTACH PARA CREACIÓN ***

                producto.IsDeleted = false;

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                // Es importante recargar las entidades de navegación para que la respuesta 
                // contenga el nombre completo del Proveedor y Categoría (opcional, pero buena práctica)
                await _context.Entry(producto).Reference(p => p.Proveedor).LoadAsync();
                await _context.Entry(producto).Reference(p => p.Categoria).LoadAsync();

                return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
            }
            catch (Exception ex)
            {
                // Devuelve el mensaje de la excepción para ayudar a la depuración
                return StatusCode(500, $"Error interno del servidor al crear: {ex.Message}");
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
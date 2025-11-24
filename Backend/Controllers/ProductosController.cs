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

        // --------------------------------------------------------------------------------
        // GET: api/Productos (Obtiene todos los activos, con filtro de búsqueda)
        // --------------------------------------------------------------------------------
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetProductos([FromQuery] string? filter = null)
        {
            if (_context.Productos == null)
            {
                return StatusCode(500, "El conjunto de entidades 'Productos' no está disponible.");
            }

            try
            {
                var query = _context.Productos
                    .Include(p => p.Categoria) // Incluye la categoría para obtener su nombre
                    .Where(p => !p.IsDeleted) // Filtrado semántico: solo productos activos
                    .AsNoTracking()
                    .AsQueryable();

                // Aplicar filtro si se proporciona
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    var lowerFilter = filter.Trim().ToLower();
                    query = query.Where(p => p.Nombre.ToLower().Contains(lowerFilter));
                }

                // Proyección de datos a un tipo anónimo para ser más eficiente y evitar ciclos
                var productos = await query
                    .Select(p => new
                    {
                        p.Id,
                        p.Nombre,
                        p.Precio,
                        p.Stock,
                        p.Unidad,
                        p.CategoriaId, // Mantenemos el ID
                        CategoriaNombre = p.Categoria.Nombre // Nombre de la categoría
                    })
                    .ToListAsync();

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

        // --------------------------------------------------------------------------------
        // GET: api/Productos/5 (Obtiene un producto activo por ID)
        // --------------------------------------------------------------------------------
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
                    .Include(p => p.Categoria) // Incluye la categoría
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

        // --------------------------------------------------------------------------------
        // PUT: api/Productos/5 (Actualizar)
        // --------------------------------------------------------------------------------
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest("El ID de la ruta no coincide con el ID del producto.");
            }

            // Aseguramos que solo actualizamos los campos necesarios o usamos Attached/Detached
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
                throw; // Lanza la excepción si es un error de concurrencia real
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al actualizar: {ex.Message}");
            }

            return NoContent(); // 204 No Content
        }

        // --------------------------------------------------------------------------------
        // POST: api/Productos (Crear)
        // --------------------------------------------------------------------------------
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            if (_context.Productos == null)
            {
                return Problem("El conjunto de entidades 'Productos' es nulo.");
            }

            try
            {
                producto.IsDeleted = false; // Asegurar que el nuevo producto esté activo
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                // 201 Created con la ubicación del nuevo recurso
                return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al crear: {ex.Message}");
            }
        }

        // --------------------------------------------------------------------------------
        // DELETE: api/Productos/5 (Eliminación Lógica / Soft Delete)
        // --------------------------------------------------------------------------------
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            try
            {
                // Usar FindAsync es rápido si ya está en memoria, pero no trae propiedades de navegación
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

                // .Update() se usa explícitamente si la entidad no está siendo rastreada, 
                // pero FindAsync la rastrea. SaveChanges() es suficiente.
                await _context.SaveChangesAsync();

                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al eliminar: {ex.Message}");
            }
        }

        // --------------------------------------------------------------------------------
        // PUT: api/Productos/restore/5 (Restaurar)
        // --------------------------------------------------------------------------------
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreProducto(int id)
        {
            try
            {
                // Usamos IgnoreQueryFilters() para encontrar el producto aunque esté eliminado
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

                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al restaurar: {ex.Message}");
            }
        }

        // --------------------------------------------------------------------------------
        // GET: api/Productos/deleteds (Obtener Eliminados)
        // --------------------------------------------------------------------------------
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosDeleteds()
        {
            // Usamos IgnoreQueryFilters() para anular el filtro IsDeleted = false
            var eliminados = await _context.Productos
                .IgnoreQueryFilters()
                .Where(p => p.IsDeleted)
                .AsNoTracking()
                .ToListAsync();

            if (!eliminados.Any())
            {
                return NotFound("No hay productos eliminados.");
            }

            return Ok(eliminados); // 200 OK
        }

        // --------------------------------------------------------------------------------
        // Método Auxiliar
        // --------------------------------------------------------------------------------
        private bool ProductoExists(int id)
        {
            // Nota: Este método verifica la existencia *activa* si tienes Query Filters globales.
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
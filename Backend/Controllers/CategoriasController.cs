using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DataContext;
using Service.Models;
// Nota: La clase Producto ahora debe tener [JsonIgnore] en la propiedad Categoria
// para evitar el ciclo de referencia.

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly StockCarniceriaContext _context;

        public CategoriasController(StockCarniceriaContext context)
        {
            _context = context;
        }

        // --- GET ALL (Todos, Activos y con Filtro) ---
        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias(string? filter = null)
        {
            if (_context.Categorias == null)
            {
                return NotFound("El conjunto de entidades 'Categorias' no está disponible.");
            }

            try
            {
                var query = _context.Categorias
                    .Include(c => c.Productos) // Carga los productos asociados
                    .Where(c => !c.IsDeleted) // Filtrado semántico: solo categorías activas
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    query = query.Where(c => c.Nombre.Contains(filter.Trim(), StringComparison.OrdinalIgnoreCase));
                }

                // Usamos AsNoTracking() para mejor rendimiento en la lectura
                var categorias = await query.AsNoTracking().ToListAsync();

                if (!categorias.Any())
                {
                    return NotFound("No se encontraron categorías que coincidan con los criterios.");
                }

                return Ok(categorias); // Retorna 200 OK
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // --- GET BY ID (Por ID) ---
        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            if (_context.Categorias == null)
            {
                return NotFound();
            }

            try
            {
                var categoria = await _context.Categorias
                    .Include(c => c.Productos)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

                if (categoria == null)
                {
                    return NotFound($"Categoría con ID {id} no encontrada o está eliminada.");
                }

                return Ok(categoria); // Retorna 200 OK
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // --- POST (Crear) ---
        // POST: api/Categorias
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            if (_context.Categorias == null)
            {
                return Problem("El conjunto de entidades 'Categorias' es nulo.");
            }

            try
            {
                categoria.IsDeleted = false;
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();

                // Retorna 201 Created con la ubicación del nuevo recurso
                return CreatedAtAction(nameof(GetCategoria), new { id = categoria.Id }, categoria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al crear: {ex.Message}");
            }
        }

        // --- PUT (Actualizar) ---
        // PUT: api/Categorias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest("El ID de la ruta no coincide con el ID de la categoría."); // 400 Bad Request
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                {
                    return NotFound(); // 404 Not Found
                }
                else
                {
                    // Propagamos la excepción de concurrencia para que sea manejada externamente si es necesario
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al actualizar: {ex.Message}");
            }

            return NoContent(); // 204 No Content
        }

        // --- DELETE (Eliminación Lógica/Soft Delete) ---
        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            try
            {
                var categoria = await _context.Categorias.FindAsync(id);
                if (categoria == null)
                {
                    return NotFound();
                }

                // Implementación de Soft Delete: marcamos como eliminado
                categoria.IsDeleted = true;
                // No es necesario llamar a .Update() si FindAsync ya está rastreando la entidad
                await _context.SaveChangesAsync();

                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al eliminar: {ex.Message}");
            }
        }

        // --- PUT (Restaurar) ---
        // PUT: api/Categorias/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreCategoria(int id)
        {
            try
            {
                // Usamos IgnoreQueryFilters() para encontrar la categoría aunque esté eliminada
                var categoria = await _context.Categorias
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (categoria == null)
                {
                    return NotFound();
                }

                if (!categoria.IsDeleted)
                {
                    return BadRequest("La categoría no se encuentra eliminada.");
                }

                categoria.IsDeleted = false;
                await _context.SaveChangesAsync();

                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al restaurar: {ex.Message}");
            }
        }

        // --- GET DELETEDS (Obtener Eliminadas) ---
        // GET: api/Categorias/deleteds
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoriasDeleteds()
        {
            // Usamos IgnoreQueryFilters() para anular el filtro IsDeleted = false
            var eliminadas = await _context.Categorias
                .IgnoreQueryFilters()
                .Where(c => c.IsDeleted)
                .AsNoTracking()
                .ToListAsync();

            if (!eliminadas.Any())
            {
                return NotFound("No hay categorías eliminadas.");
            }

            return Ok(eliminadas); // 200 OK
        }

        // --- Método Auxiliar ---
        private bool CategoriaExists(int id)
        {
            // Nota: Este método no usa IgnoreQueryFilters, por lo que solo detectará
            // si la categoría existe y no está lógicamente eliminada (si tienes Query Filters globales).
            // Si necesitas que detecte *cualquier* existencia, debes añadir .IgnoreQueryFilters()
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}
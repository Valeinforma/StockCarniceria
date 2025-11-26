using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DataContext;
using Service.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly StockCarniceriaContext _context;

        public ProveedoresController(StockCarniceriaContext context)
        {
            _context = context;
        }

        // GET: api/Proveedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedores([FromQuery] string? filter = null)
        {
            if (_context.Proveedores == null)
            {
                return StatusCode(500, "El conjunto de entidades 'Proveedores' no está disponible.");
            }

            try
            {
                var query = _context.Proveedores
                    .Where(p => !p.IsDeleted)
                    .AsNoTracking()
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    var lowerFilter = filter.Trim().ToLower();
                    query = query.Where(p => p.Nombre.ToLower().Contains(lowerFilter));
                }

                var proveedores = await query.ToListAsync();

                if (!proveedores.Any())
                {
                    return NotFound("No se encontraron proveedores activos que coincidan con los criterios.");
                }

                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al obtener proveedores: {ex.Message}");
            }
        }

        // GET: api/Proveedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> GetProveedor(int id)
        {
            if (_context.Proveedores == null)
            {
                return NotFound();
            }

            try
            {
                var proveedor = await _context.Proveedores
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

                if (proveedor == null)
                {
                    return NotFound($"Proveedor con ID {id} no encontrado o está eliminado.");
                }

                return Ok(proveedor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT: api/Proveedores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedor(int id, Proveedor proveedor)
        {
            if (id != proveedor.Id)
            {
                return BadRequest("El ID de la ruta no coincide con el ID del proveedor.");
            }

            _context.Entry(proveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(id))
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

        // POST: api/Proveedores
        [HttpPost]
        public async Task<ActionResult<Proveedor>> PostProveedor(Proveedor proveedor)
        {
            if (_context.Proveedores == null)
            {
                return Problem("El conjunto de entidades 'Proveedores' es nulo.");
            }

            try
            {
                proveedor.IsDeleted = false;
                _context.Proveedores.Add(proveedor);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProveedor), new { id = proveedor.Id }, proveedor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al crear: {ex.Message}");
            }
        }

        // DELETE: api/Proveedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            try
            {
                var proveedor = await _context.Proveedores.FindAsync(id);

                if (proveedor == null)
                {
                    return NotFound();
                }

                if (proveedor.IsDeleted)
                {
                    return BadRequest("El proveedor ya se encuentra eliminado lógicamente.");
                }

                proveedor.IsDeleted = true;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al eliminar: {ex.Message}");
            }
        }

        // PUT: api/Proveedores/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreProveedor(int id)
        {
            try
            {
                var proveedor = await _context.Proveedores
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (proveedor == null)
                {
                    return NotFound($"Proveedor con ID {id} no encontrado.");
                }

                if (!proveedor.IsDeleted)
                {
                    return BadRequest("El proveedor no se encuentra eliminado.");
                }

                proveedor.IsDeleted = false;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al restaurar: {ex.Message}");
            }
        }

        // GET: api/Proveedores/deleteds
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedoresDeleteds()
        {
            try
            {
                var eliminados = await _context.Proveedores
                    .IgnoreQueryFilters()
                    .Where(p => p.IsDeleted)
                    .AsNoTracking()
                    .ToListAsync();

                if (!eliminados.Any())
                {
                    return NotFound("No hay proveedores eliminados.");
                }

                return Ok(eliminados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al obtener eliminados: {ex.Message}");
            }
        }

        private bool ProveedorExists(int id)
        {
            return _context.Proveedores.Any(e => e.Id == id);
        }
    }
}

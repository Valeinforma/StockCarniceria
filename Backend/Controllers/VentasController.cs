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
    public class VentasController : ControllerBase
    {
        private readonly StockCarniceriaContext _context;

        public VentasController(StockCarniceriaContext context)
        {
            _context = context;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas([FromQuery] string? filter = null)
        {
            if (_context.Ventas == null)
            {
                return StatusCode(500, "El conjunto de entidades 'Ventas' no está disponible.");
            }

            try
            {
                var query = _context.Ventas
                    .Include(v => v.Vendedor)
                    .Include(v => v.Cliente)
                    .Include(v => v.Items)
                    .Where(v => !v.IsDeleted)
                    .AsNoTracking()
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    var lowerFilter = filter.Trim().ToLower();
                    query = query.Where(v => v.NombreClienteSinUsuario.ToLower().Contains(lowerFilter) ||
                                             v.Cliente.Nombre.ToLower().Contains(lowerFilter));
                }

                var ventas = await query.ToListAsync();

                if (!ventas.Any())
                {
                    return NotFound("No se encontraron ventas activas que coincidan con los criterios.");
                }

                return Ok(ventas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al obtener ventas: {ex.Message}");
            }
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVenta(int id)
        {
            if (_context.Ventas == null)
            {
                return NotFound();
            }

            try
            {
                var venta = await _context.Ventas
                    .Include(v => v.Vendedor)
                    .Include(v => v.Cliente)
                    .Include(v => v.Items)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(v => v.Id == id && !v.IsDeleted);

                if (venta == null)
                {
                    return NotFound($"Venta con ID {id} no encontrada o está eliminada.");
                }

                return Ok(venta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT: api/Ventas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenta(int id, Venta venta)
        {
            if (id != venta.Id)
            {
                return BadRequest("El ID de la ruta no coincide con el ID de la venta.");
            }

            _context.Entry(venta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(id))
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

        // POST: api/Ventas
        [HttpPost]
        public async Task<ActionResult<Venta>> PostVenta(Venta venta)
        {
            if (_context.Ventas == null)
            {
                return Problem("El conjunto de entidades 'Ventas' es nulo.");
            }

            try
            {
                venta.IsDeleted = false;
                venta.Fecha = DateTime.Now;
                _context.Ventas.Add(venta);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetVenta), new { id = venta.Id }, venta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al crear: {ex.Message}");
            }
        }

        // DELETE: api/Ventas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            try
            {
                var venta = await _context.Ventas.FindAsync(id);

                if (venta == null)
                {
                    return NotFound();
                }

                if (venta.IsDeleted)
                {
                    return BadRequest("La venta ya se encuentra eliminada lógicamente.");
                }

                venta.IsDeleted = true;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al eliminar: {ex.Message}");
            }
        }

        // PUT: api/Ventas/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreVenta(int id)
        {
            try
            {
                var venta = await _context.Ventas
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(v => v.Id == id);

                if (venta == null)
                {
                    return NotFound($"Venta con ID {id} no encontrada.");
                }

                if (!venta.IsDeleted)
                {
                    return BadRequest("La venta no se encuentra eliminada.");
                }

                venta.IsDeleted = false;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al restaurar: {ex.Message}");
            }
        }

        // GET: api/Ventas/deleteds
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentasDeleteds()
        {
            try
            {
                var eliminadas = await _context.Ventas
                    .IgnoreQueryFilters()
                    .Include(v => v.Vendedor)
                    .Include(v => v.Cliente)
                    .Include(v => v.Items)
                    .Where(v => v.IsDeleted)
                    .AsNoTracking()
                    .ToListAsync();

                if (!eliminadas.Any())
                {
                    return NotFound("No hay ventas eliminadas.");
                }

                return Ok(eliminadas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al obtener eliminadas: {ex.Message}");
            }
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.Id == id);
        }
    }
}

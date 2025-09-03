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
    public class DetalleVentasController : ControllerBase
    {
        private readonly StockCarniceriaContext _context;

        public DetalleVentasController(StockCarniceriaContext context)
        {
            _context = context;
        }

        // GET: api/DetalleVentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleVenta>>> GetDetallesVenta()
        {
            return await _context.DetallesVenta.ToListAsync();
        }

        // GET: api/DetalleVentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleVenta>> GetDetalleVenta(int id)
        {
            var detalleVenta = await _context.DetallesVenta.FindAsync(id);

            if (detalleVenta == null)
            {
                return NotFound();
            }

            return detalleVenta;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleVenta(int id, DetalleVenta detalleVenta)
        {
            if (id != detalleVenta.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleVenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleVentaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DetalleVentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleVenta>> PostDetalleVenta(DetalleVenta detalleVenta)
        {
            _context.DetallesVenta.Add(detalleVenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleVenta", new { id = detalleVenta.Id }, detalleVenta);
        }

        // DELETE: api/DetalleVentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleVenta(int id)
        {
            var detalleVenta = await _context.DetallesVenta.FindAsync(id);
            if (detalleVenta == null)
            {
                return NotFound();
            }

            _context.DetallesVenta.Remove(detalleVenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreDetalleVenta(int id)
        {
            var DetalleVenta = await _context.DetallesVenta.IgnoreQueryFilters
                ().FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (DetalleVenta == null)
            {
                return NotFound();
            }
            DetalleVenta.IsDeleted = true;
            _context.DetallesVenta.Update(DetalleVenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // GET: api/Capacitaciones
        [HttpGet("deleteds/")]
        public async Task<ActionResult<IEnumerable<DetalleVenta>>> GetDetallesVentaDeleteds()
        {
            return await _context.DetallesVenta.IgnoreQueryFilters().Where(c => c.IsDeleted).ToListAsync();
        }

        private bool DetalleVentaExists(int id)
        {
            return _context.DetallesVenta.Any(e => e.Id == id);
        }
    }
}

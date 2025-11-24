using Backend.DataContext;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        // GET: api/Productoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetProductos([FromQuery] string? filter = "")
        {
            var query = _context.Productos.AsQueryable();

            // 1. Manejo del filtro (se mantiene la eficiencia)
            if (!string.IsNullOrEmpty(filter))
            {
                var lowerFilter = filter.ToLower();
                query = query.Where(p => p.Nombre.ToLower().Contains(lowerFilter) && !p.IsDeleted);
            }
            else
            {
                query = query.Where(p => !p.IsDeleted);
            }

            // 2. Proyección con aplanamiento (Proyección eficiente)
            return await query
                .Select(p => new
                {
                    p.Id,
                    p.Nombre,
                    p.Precio,
                    p.Stock,
                    p.Unidad,
                    // Eliminamos p.CategoriaId si no lo necesitas en la respuesta

                    // 👈 APLANAMIENTO: Tomamos el nombre y lo asignamos como una nueva propiedad
                    CategoriaNombre = p.Categoria.Nombre
                })
                .ToListAsync();
        }

        // Reemplaza el método GetCapacitaciones para corregir el uso incorrecto de Contains en tipos numéricos
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetProducto(int id) // 👈 Cambia la firma a ActionResult<object>
        {
            var producto = await _context.Productos
                .Where(p => p.Id == id)
                .Select(p => new // 👈 Usamos proyección para aplanar
                {
                    p.Id,
                    p.Nombre,
                    p.Precio,
                    p.Stock,
                    p.Unidad,
                    CategoriaNombre = p.Categoria.Nombre
                })
                .FirstOrDefaultAsync();

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: api/Productoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            // 1. Desvincular la Categoria para evitar errores de seguimiento de EF.
            producto.Categoria = null;

            // 2. Asegurar que EF solo actualice el estado si la entidad no está siendo rastreada.
            // Aunque tu código actual (Entry().State = Modified) ya lo hace, esta es la forma más limpia.
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
                else
                {
                    throw;
                }
            }
            // Añadir catch para DbUpdateException para mejor diagnóstico si falla la FK.

            return NoContent();
        }

            // POST: api/Productoes
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
               // 1.SOLUCIÓN CLAVE: Desvincular la propiedad de navegación para evitar el error 500
                // Esto asegura que EF solo use CategoriaId.
                producto.Categoria = null;

                // 2. Seguridad: Forzar la autogeneración de ID y el estado inicial
                producto.Id = 0;
                producto.IsDeleted = false; // Asumimos que los productos nuevos no están eliminados

                _context.Productos.Add(producto);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex) // Capturar errores específicos de DB
                {
                    // Esto indica un problema de clave foránea (CategoriaId no existe) 
                    // o validación de modelo/base de datos.
                    return StatusCode(500, $"Error al insertar el producto. Verifique CategoriaId. Detalle: {ex.InnerException?.Message ?? ex.Message}");
                }


            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }

        // DELETE: api/Productoes/5
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
                producto.IsDeleted = true;
                _context.Productos.Update(producto);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreProducto(int id)
        {
            try
            {
                var Producto = await _context.Productos.IgnoreQueryFilters
                    ().FirstOrDefaultAsync(c => c.Id.Equals(id));
                if (Producto == null)
                {
                    return NotFound();
                }
                Producto.IsDeleted = false;
                _context.Productos.Update(Producto);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
               {
                   return StatusCode(500, $"Error interno: {ex.Message}");
               }
           }

        // GET: api/Capacitaciones
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetCapacitacionesDeleteds()
        {
            return await _context.Productos.IgnoreQueryFilters().Where(c => c.IsDeleted).ToListAsync();
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}

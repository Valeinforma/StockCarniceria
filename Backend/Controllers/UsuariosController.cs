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
    public class UsuariosController : ControllerBase
    {
        private readonly StockCarniceriaContext _context;

        public UsuariosController(StockCarniceriaContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios([FromQuery] string? filter = null)
        {
            if (_context.Usuarios == null)
            {
                return StatusCode(500, "El conjunto de entidades 'Usuarios' no está disponible.");
            }

            try
            {
                var query = _context.Usuarios
                    .Where(u => !u.IsDeleted)
                    .AsNoTracking()
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    var lowerFilter = filter.Trim().ToLower();
                    query = query.Where(u => u.Nombre.ToLower().Contains(lowerFilter));
                }

                var usuarios = await query.ToListAsync();

                if (!usuarios.Any())
                {
                    return NotFound("No se encontraron usuarios activos que coincidan con los criterios.");
                }

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al obtener usuarios: {ex.Message}");
            }
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuarios(int id)
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }

            try
            {
                var usuarios = await _context.Usuarios
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);

                if (usuarios == null)
                {
                    return NotFound($"Usuario con ID {id} no encontrado o está eliminado.");
                }

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios(int id, Usuarios usuarios)
        {
            if (id != usuarios.Id)
            {
                return BadRequest("El ID de la ruta no coincide con el ID del usuario.");
            }

            _context.Entry(usuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuarios>> PostUsuarios(Usuarios usuarios)
        {
            if (_context.Usuarios == null)
            {
                return Problem("El conjunto de entidades 'Usuarios' es nulo.");
            }

            try
            {
                usuarios.IsDeleted = false;
                _context.Usuarios.Add(usuarios);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetUsuarios), new { id = usuarios.Id }, usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al crear: {ex.Message}");
            }
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarios(int id)
        {
            try
            {
                var usuarios = await _context.Usuarios.FindAsync(id);

                if (usuarios == null)
                {
                    return NotFound();
                }

                if (usuarios.IsDeleted)
                {
                    return BadRequest("El usuario ya se encuentra eliminado lógicamente.");
                }

                usuarios.IsDeleted = true;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al eliminar: {ex.Message}");
            }
        }

        // PUT: api/Usuarios/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreUsuarios(int id)
        {
            try
            {
                var usuarios = await _context.Usuarios
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (usuarios == null)
                {
                    return NotFound($"Usuario con ID {id} no encontrado.");
                }

                if (!usuarios.IsDeleted)
                {
                    return BadRequest("El usuario no se encuentra eliminado.");
                }

                usuarios.IsDeleted = false;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al restaurar: {ex.Message}");
            }
        }

        // GET: api/Usuarios/deleteds
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuariosDeleteds()
        {
            try
            {
                var eliminados = await _context.Usuarios
                    .IgnoreQueryFilters()
                    .Where(u => u.IsDeleted)
                    .AsNoTracking()
                    .ToListAsync();

                if (!eliminados.Any())
                {
                    return NotFound("No hay usuarios eliminados.");
                }

                return Ok(eliminados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor al obtener eliminados: {ex.Message}");
            }
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}

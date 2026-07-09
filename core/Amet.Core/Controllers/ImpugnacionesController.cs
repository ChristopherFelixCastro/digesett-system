using Amet.Core.Data;
using Amet.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amet.Core.Controllers
{
    [ApiController]
    [Route("api/v1/impugnaciones")]
    public class ImpugnacionesController : ControllerBase
    {
        private readonly AmetDbContext _context;

        public ImpugnacionesController(AmetDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetImpugnaciones()
        {
            return Ok(await _context.Impugnaciones.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImpugnacion(int id)
        {
            var impugnacion = await _context.Impugnaciones.FindAsync(id);

            if (impugnacion == null)
                return NotFound();

            return Ok(impugnacion);
        }

        [HttpPost]
        public async Task<IActionResult> CrearImpugnacion([FromBody] Impugnacion impugnacion)
        {
            _context.Impugnaciones.Add(impugnacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetImpugnacion), new { id = impugnacion.Id }, impugnacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarImpugnacion(int id, Impugnacion impugnacion)
        {
            if (id != impugnacion.Id)
                return BadRequest();

            _context.Entry(impugnacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarImpugnacion(int id)
        {
            var impugnacion = await _context.Impugnaciones.FindAsync(id);

            if (impugnacion == null)
                return NotFound();

            _context.Impugnaciones.Remove(impugnacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
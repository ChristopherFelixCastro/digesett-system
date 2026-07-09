using Amet.Core.Data;
using Amet.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amet.Core.Controllers
{
    [ApiController]
    [Route("api/v1/conductores")]
    public class ConductoresController : ControllerBase
    {
        private readonly AmetDbContext _context;

        public ConductoresController(AmetDbContext context)
        {
            _context = context;
        }

        // Obtener todos
        [HttpGet]
        public async Task<IActionResult> GetConductores()
        {
            return Ok(await _context.Conductores.ToListAsync());
        }

        // Obtener por Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConductor(Guid id)
        {
            var conductor = await _context.Conductores.FindAsync(id);

            if (conductor == null)
                return NotFound();

            return Ok(conductor);
        }

        // Crear
        [HttpPost]
        public async Task<IActionResult> CrearConductor([FromBody] Conductor conductor)
        {
            conductor.Id = Guid.NewGuid();

            _context.Conductores.Add(conductor);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConductor), new { id = conductor.Id }, conductor);
        }

        // Actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarConductor(Guid id, Conductor conductor)
        {
            if (id != conductor.Id)
                return BadRequest();

            _context.Entry(conductor).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Eliminar
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarConductor(Guid id)
        {
            var conductor = await _context.Conductores.FindAsync(id);

            if (conductor == null)
                return NotFound();

            _context.Conductores.Remove(conductor);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
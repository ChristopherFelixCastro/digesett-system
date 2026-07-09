using Amet.Core.Data;
using Amet.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amet.Core.Controllers
{
    [ApiController]
    [Route("api/v1/actas")]
    public class ActasController : ControllerBase
    {
        private readonly AmetDbContext _context;

        public ActasController(AmetDbContext context)
        {
            _context = context;
        }

        // Obtener todas
        [HttpGet]
        public async Task<IActionResult> GetActas()
        {
            return Ok(await _context.Actas.ToListAsync());
        }

        // Obtener por Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActa(Guid id)
        {
            var acta = await _context.Actas.FindAsync(id);

            if (acta == null)
                return NotFound();

            return Ok(acta);
        }

        // Crear
        [HttpPost]
        public async Task<IActionResult> CrearActa([FromBody] Acta acta)
        {
            acta.Id = Guid.NewGuid();

            _context.Actas.Add(acta);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActa), new { id = acta.Id }, acta);
        }

        // Actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarActa(Guid id, Acta acta)
        {
            if (id != acta.Id)
                return BadRequest();

            _context.Entry(acta).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Eliminar
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarActa(Guid id)
        {
            var acta = await _context.Actas.FindAsync(id);

            if (acta == null)
                return NotFound();

            _context.Actas.Remove(acta);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
using Amet.Core.Data;
using Amet.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amet.Core.Controllers
{
    [ApiController]
    [Route("api/v1/canodromos")]
    public class CanodromosController : ControllerBase
    {
        private readonly AmetDbContext _context;

        public CanodromosController(AmetDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCanodromos()
        {
            return Ok(await _context.Canodromos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCanodromo(int id)
        {
            var canodromo = await _context.Canodromos.FindAsync(id);

            if (canodromo == null)
                return NotFound();

            return Ok(canodromo);
        }

        [HttpPost]
        public async Task<IActionResult> CrearCanodromo([FromBody] Canodromo canodromo)
        {
            _context.Canodromos.Add(canodromo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCanodromo), new { id = canodromo.Id }, canodromo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCanodromo(int id, Canodromo canodromo)
        {
            if (id != canodromo.Id)
                return BadRequest();

            _context.Entry(canodromo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCanodromo(int id)
        {
            var canodromo = await _context.Canodromos.FindAsync(id);

            if (canodromo == null)
                return NotFound();

            _context.Canodromos.Remove(canodromo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
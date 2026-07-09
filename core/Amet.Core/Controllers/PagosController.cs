using Amet.Core.Data;
using Amet.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amet.Core.Controllers
{
    [ApiController]
    [Route("api/v1/pagos")]
    public class PagosController : ControllerBase
    {
        private readonly AmetDbContext _context;

        public PagosController(AmetDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPagos()
        {
            return Ok(await _context.Pagos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPago(Guid id)
        {
            var pago = await _context.Pagos.FindAsync(id);

            if (pago == null)
                return NotFound();

            return Ok(pago);
        }

        [HttpPost]
        public async Task<IActionResult> CrearPago([FromBody] Pago pago)
        {
            pago.Id = Guid.NewGuid();

            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPago), new { id = pago.Id }, pago);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPago(Guid id, Pago pago)
        {
            if (id != pago.Id)
                return BadRequest();

            _context.Entry(pago).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPago(Guid id)
        {
            var pago = await _context.Pagos.FindAsync(id);

            if (pago == null)
                return NotFound();

            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
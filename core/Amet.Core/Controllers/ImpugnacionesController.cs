using Amet.Core.Data;
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
    }
}
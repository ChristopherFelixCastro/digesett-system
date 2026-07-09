using Amet.Core.Data;
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

        [HttpGet]
        public async Task<IActionResult> GetActas()
        {
            return Ok(await _context.Actas.ToListAsync());
        }
    }
}
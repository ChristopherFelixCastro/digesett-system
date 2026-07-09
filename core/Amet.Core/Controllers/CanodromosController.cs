using Amet.Core.Data;
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
    }
}
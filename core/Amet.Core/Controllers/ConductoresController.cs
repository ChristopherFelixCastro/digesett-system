using Amet.Core.Data;
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

        [HttpGet]
        public async Task<IActionResult> GetConductores()
        {
            return Ok(await _context.Conductores.ToListAsync());
        }
    }
} 
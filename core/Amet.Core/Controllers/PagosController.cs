using Amet.Core.Data;
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
    }
}
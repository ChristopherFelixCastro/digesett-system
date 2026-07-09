using Microsoft.AspNetCore.Mvc;

namespace Amet.Core.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok(new
            {
                token = "token_de_prueba",
                rol = "ADMIN",
                usuario_id = Guid.NewGuid()
            });
        }
    }
}
using Amet.Core.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Amet.Core.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AmetDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AmetDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u =>
                    u.Email == request.Email &&
                    u.Estado == "ACTIVO");

            if (usuario == null)
                return Unauthorized(new
                {
                    mensaje = "Usuario no encontrado."
                });

            if (usuario.PasswordHash != request.Password)
                return Unauthorized(new
                {
                    mensaje = "Contraseña incorrecta."
                });

            var secretKey = _configuration["Jwt:SecretKey"];

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey!));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("usuario_id", usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Rol)
            };

            var token = new JwtSecurityToken(

                claims: claims,

                expires: DateTime.UtcNow.AddHours(2),

                signingCredentials: credentials

            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                usuario.Id,
                usuario.Nombre,
                usuario.Email,
                usuario.Rol
            });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = "";

        public string Password { get; set; } = "";
    }
}
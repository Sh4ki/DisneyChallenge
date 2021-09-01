using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Api.Controllers
{
    [Route("/auth/login")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUsuarioService service;
        private readonly IConfiguration configuration;

        public TokenController(IUsuarioService service, IConfiguration configuration)
        {
            this.service = service;
            this.configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin login)
        {
            var user = await IsValidUser(login);
            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(token);
            }
            return NotFound();
        }
        private async Task<Usuario> IsValidUser(UserLogin login)
        {
            var user = await service.Check(login);
            return user;
        }

        private string GenerateToken(Usuario security)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, security.NombreUsuario),
                new Claim("User", security.Nombre),
                new Claim(ClaimTypes.Role, "Administrador"),
            };

            //Payload
            var payload = new JwtPayload
            (
                configuration["Authentication:Issuer"],
                configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

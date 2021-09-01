using Disney.Core.Entities;
using Disney.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disney.Api.Controllers
{
    [Route("/auth/register")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IUsuarioService service;

        public SecurityController(IUsuarioService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Add(Usuario usuario)
        {
            await service.Add(usuario);
            return Ok();
        }
    }
}

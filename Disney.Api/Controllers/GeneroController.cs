using Disney.Core.Entities;
using Disney.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disney.Api.Controllers
{
    [Authorize]
    [Route("/genders")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroService service;

        public GeneroController(IGeneroService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Genero genero)
        {
            await service.Add(genero);
            return Ok();
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await service.Delete(Id);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = service.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await service.GetById(Id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(Genero genero)
        {
            service.Update(genero);
            return Ok();
        }
    }

}


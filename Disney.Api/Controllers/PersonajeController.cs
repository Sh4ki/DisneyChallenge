using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Filters;
using Disney.Core.Interfaces;
using Disney.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disney.Api.Controllers
{
    [Authorize]
    [Route("/characters")]
    [ApiController]
    public class PersonajeController : ControllerBase
    {
        private readonly IPersonajeService service;

        public PersonajeController(IPersonajeService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Add(CharacterDTO personaje)
        {
            var _personaje = DtoMapper.Mapto<Personaje>(personaje);
            await service.Add(_personaje);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await service.Delete(Id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCharacters([FromQuery] FilterPersonaje filter)
        {
            if (filter.age!=null||filter.movies!=null||!string.IsNullOrEmpty(filter.name))
            {
                var result = await service.GetAllCharacters(filter);
                return Ok(result);
            }
            else
            {
                var result = service.GetAllCharacters();
                return Ok(result);
            } 
        }

        [HttpPut]
        public async Task<IActionResult> Update(CharacterDTO personaje)
        {
            var _personaje = DtoMapper.Mapto<Personaje>(personaje);
            await service.Update(_personaje);
            return Ok();
        }
    }
}

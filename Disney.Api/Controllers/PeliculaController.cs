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
    [Route("/movies")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService service;

        public PeliculaController(IPeliculaService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Add(PelisDTO pelis)
        {
            var _pelis = DtoMapper.Mapto<Pelicula>(pelis);
            await service.Add(_pelis);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await service.Delete(Id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDetailMovies([FromQuery] FilterPelicula filter)
        {
            if (filter.genre != null || !string.IsNullOrEmpty(filter.name) || !string.IsNullOrEmpty(filter.order))
            {
                var result = await service.GetAllDetailMovies(filter);
                return Ok(result);
            }
            else
            {
                var result = service.GetAllMovies();
                return Ok(result);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(PelisDTO pelis)
        {
            var _pelis = DtoMapper.Mapto<Pelicula>(pelis);
            await service.Update(_pelis);
            return Ok();
        }
    }
}

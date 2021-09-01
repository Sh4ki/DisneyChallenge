using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Filters;
using Disney.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Core.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaRepository repository;

        public PeliculaService(IPeliculaRepository repository)
        {
            this.repository = repository;
        }
        public async Task Add(Pelicula pelicula)
        {
            await repository.Add(pelicula);
        }

        public async Task<bool> Delete(int Id)
        {
            return await repository.Delete(Id);
        }

        public async Task<IEnumerable<Pelicula>> GetAllDetailMovies(FilterPelicula filter)
        {
            return await repository.GetAllDetailMovies(filter);
        }

        public IEnumerable<PeliculaDTO> GetAllMovies()
        {
            return repository.GetAllMovies();
        }

        public async Task<Pelicula> GetById(int Id)
        {
            return await repository.GetById(Id);
        }

        public async Task Update(Pelicula pelicula)
        {
            await repository.Update(pelicula);
        }
    }
}

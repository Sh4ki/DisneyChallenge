using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Core.Interfaces
{
    public interface IPeliculaRepository
    {
        Task Add(Pelicula pelicula);
        Task<bool> Delete(int Id);
        Task<IEnumerable<Pelicula>> GetAllDetailMovies(FilterPelicula filter);
        IEnumerable<PeliculaDTO> GetAllMovies();
        Task<Pelicula> GetById(int Id);
        Task Update(Pelicula pelicula);
    }
}
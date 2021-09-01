using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Filters;
using Disney.Core.Interfaces;
using Disney.Infrastructure.Data;
using Disney.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly ContextDB context;

        public PeliculaRepository(ContextDB context)
        {
            this.context = context;
        }
        public async Task Add(Pelicula pelicula)
        {
            await context.Peliculas.AddAsync(pelicula);
            await context.SaveChangesAsync();
        }
        public async Task Update(Pelicula pelicula)
        {
            context.Peliculas.Update(pelicula);
            await context.SaveChangesAsync();
        }
        public IEnumerable<PeliculaDTO> GetAllMovies()
        {
            var peli = context.Peliculas.AsEnumerable();
            var peliDto = DtoMapper.Mapto<IEnumerable<PeliculaDTO>>(peli);
            return peliDto;
        }
        public async Task<IEnumerable<Pelicula>> GetAllDetailMovies(FilterPelicula filter)
        {
            IEnumerable<Pelicula> peli;
            if (string.IsNullOrEmpty(filter.order))
            {
                if (filter.genre!=null)
                {
                    var genero = await context.Generos.FindAsync(filter.genre);
                    peli = context.Peliculas.Include(i=>i.Personajes).Where(x => x.Generos.Contains(genero));
                }
                else
                {
                    peli = context.Peliculas.Include(i => i.Personajes).Where(x => x.Titulo.Contains(filter.name));
                }
            }
            else
            {
                if (filter.order.ToUpper().Equals("ASC"))
                {
                    peli = context.Peliculas.Include(i => i.Personajes).OrderBy(x => x.FechaCreacion).AsEnumerable();
                }
                else
                {
                    peli = context.Peliculas.Include(i => i.Personajes).OrderByDescending(x => x.FechaCreacion).AsEnumerable();
                }
            }

            return peli;
        }
        public async Task<Pelicula> GetById(int Id)
        {
            return await context.Peliculas.FindAsync(Id);
        }
        public async Task<bool> Delete(int Id)
        {
            var peli = await context.Peliculas.FindAsync(Id);
            if (peli != null)
            {
                context.Peliculas.Remove(peli);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

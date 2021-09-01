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
    public class PersonajeRepository : IPersonajeRepository
    {
        private readonly ContextDB context;

        public PersonajeRepository(ContextDB context)
        {
            this.context = context;
        }
        public async Task Add(Personaje personaje)
        {
            await context.Personajes.AddAsync(personaje);
            await context.SaveChangesAsync();
        }
        public async Task Update(Personaje personaje)
        {
            context.Personajes.Update(personaje);
            await context.SaveChangesAsync();

        }
        public IEnumerable<PersonajeDTO> GetAllCharacters()
        {
            var characters = context.Personajes.AsEnumerable();
            var characterDto = DtoMapper.Mapto<IEnumerable<PersonajeDTO>>(characters);
            return characterDto;
        }
        public async Task<IEnumerable<Personaje>> GetAllCharacters(FilterPersonaje filterPersonaje)
        {
            var movie = await context.Peliculas.FirstOrDefaultAsync(x => x.Id == filterPersonaje.movies);
            var characters = context.Personajes.Include(i => i.Peliculas)
                .Where(x =>!string.IsNullOrEmpty(filterPersonaje.name) ? x.Nombre.Contains(filterPersonaje.name) :
                filterPersonaje.age != null ? x.Edad == filterPersonaje.age : x.Peliculas.Contains(movie)).AsEnumerable();
            return characters;
        }
        public async Task<bool> Delete(int Id)
        {
            var personaje = await context.Personajes.FindAsync(Id);
            if (personaje != null)
            {
                context.Personajes.Remove(personaje);
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

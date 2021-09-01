using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Filters;
using Disney.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Core.Services
{
    public class PersonajeService : IPersonajeService
    {
        private readonly IPersonajeRepository repository;

        public PersonajeService(IPersonajeRepository repository)
        {
            this.repository = repository;
        }
        public async Task Add(Personaje personaje)
        {
            await repository.Add(personaje);
        }

        public async Task<bool> Delete(int Id)
        {
            return await repository.Delete(Id);
        }

        public IEnumerable<PersonajeDTO> GetAllCharacters()
        {
            return repository.GetAllCharacters();
        }

        public async Task<IEnumerable<Personaje>> GetAllCharacters(FilterPersonaje filterPersonaje)
        {
            return await repository.GetAllCharacters(filterPersonaje);
        }

        public async Task Update(Personaje personaje)
        {
            await repository .Update(personaje);
        }
    }
}

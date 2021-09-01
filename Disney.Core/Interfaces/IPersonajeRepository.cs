using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Core.Interfaces
{
    public interface IPersonajeRepository
    {
        Task Add(Personaje personaje);
        Task<bool> Delete(int Id);
        IEnumerable<PersonajeDTO> GetAllCharacters();
        Task<IEnumerable<Personaje>> GetAllCharacters(FilterPersonaje filterPersonaje);
        Task Update(Personaje personaje);
    }
}
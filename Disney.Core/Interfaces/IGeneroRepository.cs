using Disney.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Core.Interfaces
{
    public interface IGeneroRepository
    {
        Task Add(Genero genero);
        Task<bool> Delete(int Id);
        IEnumerable<Genero> GetAll();
        Task<Genero> GetById(int Id);
        Task Update(Genero genero);
    }
}
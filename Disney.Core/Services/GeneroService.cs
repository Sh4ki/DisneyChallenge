using Disney.Core.Entities;
using Disney.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Core.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository repository;

        public GeneroService(IGeneroRepository repository)
        {
            this.repository = repository;
        }
        public async Task Add(Genero genero)
        {
            await repository.Add(genero);
        }

        public async Task<bool> Delete(int Id)
        {
            return await repository.Delete(Id);
        }

        public IEnumerable<Genero> GetAll()
        {
            return repository.GetAll();
        }

        public async Task<Genero> GetById(int Id)
        {
            return await repository.GetById(Id);
        }

        public async Task Update(Genero genero)
        {
            await repository.Update(genero);
        }
    }
}

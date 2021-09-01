using Disney.Core.Entities;
using Disney.Core.Interfaces;
using Disney.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly ContextDB context;

        public GeneroRepository(ContextDB context)
        {
            this.context = context;
        }
        public async Task Add(Genero genero)
        {
            await context.Generos.AddAsync(genero);
            await context.SaveChangesAsync();
        }
        public async Task Update(Genero genero)
        {
            context.Generos.Update(genero);
            await context.SaveChangesAsync();
        }
        public IEnumerable<Genero> GetAll()
        {
            return context.Generos.AsEnumerable();
        }
        public async Task<Genero> GetById(int Id)
        {
            return await context.Generos.FindAsync(Id);
        }
        public async Task<bool> Delete(int Id)
        {
            var gen = await context.Generos.FindAsync(Id);
            if (gen != null)
            {
                context.Generos.Remove(gen);
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

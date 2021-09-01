using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            this.repository = repository;
        }
        public async Task Add(Usuario usuario)
        {
            await repository.Add(usuario);
        }

        public async Task<bool> Delete(int Id)
        {
            return await repository.Delete(Id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return repository.GetAll();
        }

        public async Task<Usuario> GetById(int Id)
        {
            return await repository.GetById(Id);
        }

        public async Task Update(Usuario usuario)
        {
            await repository.Update(usuario);
        }
        public async Task<Usuario> Check(UserLogin login)
        {
            var user = await repository.GetUserByCredentials(login);
            return user;
        }
    }
}

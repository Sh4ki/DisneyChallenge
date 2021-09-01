using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Interfaces;
using Disney.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ContextDB context;

        public UsuarioRepository(ContextDB context)
        {
            this.context = context;
        }
        public async Task Add(Usuario usuario)
        {
            await context.Usuarios.AddAsync(usuario);
            await context.SaveChangesAsync();
        }
        public async Task Update(Usuario usuario)
        {
            context.Usuarios.Update(usuario);
            await context.SaveChangesAsync();
        }
        public IEnumerable<Usuario> GetAll()
        {
            return context.Usuarios.AsEnumerable();
        }
        public async Task<Usuario> GetById(int Id)
        {
            return await context.Usuarios.FindAsync(Id);
        }
        public async Task<bool> Delete(int Id)
        {
            var usuario = await context.Usuarios.FindAsync(Id);
            if (usuario != null)
            {
                context.Usuarios.Remove(usuario);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Usuario> GetUserByCredentials(UserLogin login)
        {
            return await context.Usuarios.FirstOrDefaultAsync(x=>x.NombreUsuario.Equals(login.User)&&x.Contrasenia.Equals(login.Password));
        }
    }
}

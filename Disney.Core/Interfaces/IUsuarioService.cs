﻿using Disney.Core.DTOs;
using Disney.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task Add(Usuario usuario);
        Task<bool> Delete(int Id);
        IEnumerable<Usuario> GetAll();
        Task<Usuario> GetById(int Id);
        Task Update(Usuario usuario);
        Task<Usuario> Check(UserLogin login);
    }
}
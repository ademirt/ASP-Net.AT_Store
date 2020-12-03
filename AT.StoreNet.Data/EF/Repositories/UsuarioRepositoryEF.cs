using AT.StoreNet.Domain.Contracts.Repositories;
using AT.StoreNet.Domain.Entities;
using System.Linq;
using System.Collections.Generic;
using System;

namespace AT.StoreNet.Data.EF.Repositories
{
    public class UsuarioRepositoryEF : RepositoryEF<Usuario>, IUsuarioRepository
    {
        public Usuario Get(string email)
        {
            return _db.Usuarios.FirstOrDefault(u=>u.Email.ToLower() == email.ToLower());
        }
    }
}

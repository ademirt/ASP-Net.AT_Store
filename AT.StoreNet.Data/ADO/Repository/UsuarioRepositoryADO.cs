using AT.StoreNet.Domain.Contracts.Repositories;
using AT.StoreNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AT.StoreNet.Data.ADO.Repository
{
    public class UsuarioRepositoryADO : IUsuarioRepository
    {
        private readonly ATStoreDataContextADO _db;
        public UsuarioRepositoryADO(ATStoreDataContextADO db)
        {
            _db = db;
        }

        public Usuario Get(string email)
        {
            var query = $@"SELECT u.Id,u.Nome, u.Email,U.Senha, u.DtCadastro  
                            FROM Usuario u
                           WHERE email = '{email}'";

            var dtRead = _db.ExecuteCommandWithData(query);


            if (dtRead.HasRows)
            {
                var usuarios = new List<Usuario>();

                while (dtRead.Read())
                {
                    usuarios.Add(new Usuario()
                    {
                        Id = (int)dtRead["Id"],
                        Nome = dtRead["Nome"].ToString(),
                        Email = dtRead["Email"].ToString(),
                        Senha = dtRead["Senha"].ToString(),
                        DtCadastro = (DateTime)dtRead["DtCadastro"]

                    });
                }
                dtRead.Close();
                return usuarios.First();
            }

            return null;
        }

        public void Dispose()
        {
        }

        public void Add(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Usuario entity)
        {
            throw new NotImplementedException();
        }        

        public void Edit(Usuario entity)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Usuario> Get()
        {
            throw new NotImplementedException();
        }

        public Usuario Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}

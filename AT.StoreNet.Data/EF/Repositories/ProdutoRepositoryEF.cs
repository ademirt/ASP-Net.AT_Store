using AT.StoreNet.Domain.Contracts.Repositories;
using AT.StoreNet.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AT.StoreNet.Data.EF.Repositories
{
    public class ProdutoRepositoryEF : RepositoryEF<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> GetByNameContains(string str)
        {
            return _db.Produtos.Where(s => s.Nome.Contains(str.ToLower()));
        }
    }
}

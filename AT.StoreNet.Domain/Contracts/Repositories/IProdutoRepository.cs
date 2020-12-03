using AT.StoreNet.Domain.Entities;
using System.Collections.Generic;

namespace AT.StoreNet.Domain.Contracts.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> GetByNameContains(string str);
    }
}

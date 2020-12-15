using AT.StoreNet.Domain.Contracts.Repositories;
using AT.StoreNet.Domain.Entities;

namespace AT.StoreNet.Data.EF.Repositories
{
    public class TipoProdutoRepositoryEF : RepositoryEF<TipoProduto>, ITipoProdutoRepository
    {
        public TipoProdutoRepositoryEF(ATStoreDataContextEF db) : base(db)
        {
        }
    }
}

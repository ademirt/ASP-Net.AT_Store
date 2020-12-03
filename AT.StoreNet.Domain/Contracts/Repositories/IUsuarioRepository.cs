using AT.StoreNet.Domain.Entities;

namespace AT.StoreNet.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario Get(string email);
    }
}

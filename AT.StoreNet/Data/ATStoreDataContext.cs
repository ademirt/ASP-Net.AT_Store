using AT.StoreNet.Models;
using System.Data.Entity;

namespace AT.StoreNet.Data
{
    public class ATStoreDataContext : DbContext
    {
        public ATStoreDataContext() : base("ATStore_DB")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoProduto> TipoProdutos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
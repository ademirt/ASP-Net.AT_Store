using AT.StoreNet.Domain.Entities;
using System.Data.Entity;

namespace AT.StoreNet.Data.EF
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Maps.ProdutoMap());
            modelBuilder.Configurations.Add(new Maps.TipoProdutoMap());
            modelBuilder.Configurations.Add(new Maps.UsuarioMap());
        }
    }
}

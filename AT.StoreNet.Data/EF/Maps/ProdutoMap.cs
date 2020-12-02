using AT.StoreNet.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AT.StoreNet.Data.EF.Maps
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            //Tabela
            ToTable(nameof(Produto));

            //PK da tabela
            HasKey(pk => pk.Id);

            //Colunas
            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnName("Nome")
                .IsRequired();

            Property(c => c.Preco)
                .HasColumnType("money")
                .IsRequired();

            Property(c => c.Qtde)
                .HasColumnName("Quantidade")
                .IsRequired();

            Property(c => c.TipoProdutoId);

            Property(c => c.DtCadastro);


            //Relacionamento
            HasRequired(p => p.TipoProduto)
                .WithMany(t => t.Produtos)
                .HasForeignKey(fk => fk.TipoProdutoId);
        }
    }
}

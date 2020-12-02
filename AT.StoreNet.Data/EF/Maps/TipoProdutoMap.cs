using AT.StoreNet.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AT.StoreNet.Data.EF.Maps
{
    public class TipoProdutoMap : EntityTypeConfiguration<TipoProduto>
    {
        public TipoProdutoMap()
        {
            //Tabela
            ToTable(nameof(TipoProduto));

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

            Property(c => c.DtCadastro);
        }
    }
}
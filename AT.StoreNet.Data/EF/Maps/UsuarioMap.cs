using AT.StoreNet.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AT.StoreNet.Data.EF.Maps
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            //Tabela
            ToTable(nameof(Usuario));

            //PK da tabela
            HasKey(pk => pk.Id);

            //Colunas
            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.Email)
                .HasColumnType("varchar")
                .HasMaxLength(85)
                .IsRequired()
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UK_dbo.Usuario.Email") { IsUnique = true })
                    );

            Property(c => c.Senha)
                .HasColumnType("char")
                .HasMaxLength(90)
                .IsRequired();

            Property(c => c.DtCadastro);
        }
    }
}

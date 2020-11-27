using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AT.StoreNet.Models
{
    [Table(nameof(Produto))]
    public class Produto : Entity
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório!")]
        [Column(TypeName = "varchar"), StringLength(100)]
        public string Nome { get; set; }

        [Display(Name = "Preço")]
        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Campo {0} é obrigatório!")]
        public decimal? Preco { get; set; }

        [Column("Quantidade")]
        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Campo {0} é obrigatório!")]
        public short? Qtde { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório!")]
        public int TipoProdutoId { get; set; }

        [ForeignKey(nameof(TipoProdutoId))]
        public virtual TipoProduto TipoProduto { get; set; }
    }
}
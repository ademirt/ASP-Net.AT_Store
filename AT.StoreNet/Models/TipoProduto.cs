using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AT.StoreNet.Models
{
    [Table(nameof(TipoProduto))]
    public class TipoProduto : Entity
    {
        [Required, Column(TypeName = "varchar"), StringLength(100)]
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
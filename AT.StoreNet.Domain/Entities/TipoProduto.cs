using System.Collections.Generic;

namespace AT.StoreNet.Domain.Entities
{
    public class TipoProduto : Entity
    {
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}

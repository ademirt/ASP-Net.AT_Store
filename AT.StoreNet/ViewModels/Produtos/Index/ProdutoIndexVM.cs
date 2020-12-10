using System;

namespace AT.StoreNet.ViewModels.Produtos.Index
{
    public class ProdutoIndexVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public short Qtde { get; set; }

        public string Tipo { get; set; }

        public DateTime DtCadastro { get; set; } = DateTime.Now;
    }
}

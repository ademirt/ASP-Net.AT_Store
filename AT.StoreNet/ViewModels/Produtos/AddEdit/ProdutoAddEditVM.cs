using System;
using System.ComponentModel.DataAnnotations;

namespace AT.StoreNet.ViewModels.Produtos.AddEdit
{
    public class ProdutoAddEditVM
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public short Qtde { get; set; }

        [Display(Name ="Tipo de produto")]
        public int TipoProdutoId { get; set; }
        public DateTime DtCadastro { get; set; }

        public ProdutoAddEditVM()
        {
            DtCadastro = DateTime.Now;
        }
    }
}

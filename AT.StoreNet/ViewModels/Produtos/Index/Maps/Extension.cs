using AT.StoreNet.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AT.StoreNet.ViewModels.Produtos.Index.Maps
{
    public static class Extension
    {
        public static IEnumerable<ProdutoIndexVM> ToProdutoIndexVM(this IEnumerable<Produto> data)
        {
            return data.Select(p => new ProdutoIndexVM()
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                Tipo = p.TipoProduto.Nome,
                Qtde = p.Qtde,
                DtCadastro = p.DtCadastro
            });
        }
    }
}

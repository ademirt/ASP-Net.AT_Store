using AT.StoreNet.Domain.Entities;

namespace AT.StoreNet.ViewModels.Produtos.AddEdit.Maps
{
    public static class Extension
    {
        public static ProdutoAddEditVM ToProdutoAddEditVM(this Produto model)
        {
            return new ProdutoAddEditVM() { 
                Id = model.Id,
                Nome = model.Nome,
                Preco = model.Preco,
                TipoProdutoId = model.TipoProdutoId,
                Qtde = model.Qtde,
                DtCadastro = model.DtCadastro
            };
        }

        public static Produto ToProduto(this ProdutoAddEditVM model)
        {
            return new Produto()
            {
                Id = model.Id,
                Nome = model.Nome,
                Preco = model.Preco,
                TipoProdutoId = model.TipoProdutoId,
                Qtde = model.Qtde,
                DtCadastro = model.DtCadastro
            };
        }

    }
}

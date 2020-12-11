using AT.StoreNet.Controllers;
using AT.StoreNet.Domain.Contracts.Repositories;
using AT.StoreNet.Domain.Entities;
using AT.StoreNet.ViewModels.Produtos.Index;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AT.StoreNet.Tests.UI.Controllers
{
    [TestClass, TestCategory("Controllers/ProdutosController")]
    public class ProdutosControllerTest
    {
        //testar o método index para retornar a view com o modelo correto
        [TestMethod]
        public void MetodoIndex()
        {
            //arrange
            var produtosController = new ProdutosController(new ProdutoRepositoryFake(), new TipoProdutoRepositoryFake());

            //act
            var result = produtosController.Index();
            var model = result.Model as IEnumerable<ProdutoIndexVM>;

            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            Assert.AreEqual(3, model.Count());
            Assert.IsNotNull(model);

        }
    }

    public class ProdutoRepositoryFake : IProdutoRepository
    {
        public void Add(Produto entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Produto entity)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Edit(Produto entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Produto> Get()
        {
            var tipo1 = new TipoProduto() { Id = 1, Nome = "tipo 1" };
            var tipo2 = new TipoProduto() { Id = 2, Nome = "tipo 2" };

            return new List<Produto>() { 
                new Produto(){Id = 1 , Nome = "produtoXX-1", Preco = 15, Qtde = 19, TipoProdutoId = tipo1.Id, TipoProduto = tipo1 },
                new Produto(){Id = 2 , Nome = "produtoXX-2", Preco = 15, Qtde = 19, TipoProdutoId = tipo2.Id, TipoProduto = tipo2 },
                new Produto(){Id = 3 , Nome = "produtoXX-3", Preco = 15, Qtde = 19, TipoProdutoId = tipo2.Id, TipoProduto = tipo2 }
            };
        }

        public Produto Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Produto> GetByNameContains(string str)
        {
            throw new System.NotImplementedException();
        }
    }

    public class TipoProdutoRepositoryFake : ITipoProdutoRepository
    {
        public void Add(Produto entity)
        {
            throw new System.NotImplementedException();
        }

        public void Add(TipoProduto entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Produto entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TipoProduto entity)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Edit(Produto entity)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(TipoProduto entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Produto> Get()
        {
            throw new System.NotImplementedException();
        }

        public Produto Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Produto> GetByNameContains(string str)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<TipoProduto> IRepository<TipoProduto>.Get()
        {
            throw new System.NotImplementedException();
        }

        TipoProduto IRepository<TipoProduto>.Get(int id)
        {
            throw new System.NotImplementedException();
        }
    }

}

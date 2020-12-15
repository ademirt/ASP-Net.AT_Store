using AT.StoreNet.Domain.Entities;
using AT.StoreNet.Domain.Helpers;
using System.Collections.Generic;
using System.Data.Entity;

namespace AT.StoreNet.Data.EF
{
    internal class DbInitializer : CreateDatabaseIfNotExists<ATStoreDataContextEF>
    {
        protected override void Seed(ATStoreDataContextEF context)
        {
            var alimento = new TipoProduto() { Nome = "Alimento" };
            var higiene = new TipoProduto() { Nome = "Higiene" };
            var limpeza = new TipoProduto() { Nome = "Limpeza" };
            var eletronico = new TipoProduto() { Nome = "Eletrônico" };

            var produtos = new List<Produto>() {
                new Produto() {Nome = "Picanha", Preco = 70.5M, TipoProduto = alimento, Qtde = 10 },
                new Produto() {Nome = "Iogurte", Preco = 10.25M, TipoProduto = alimento, Qtde = 33 },
                new Produto() {Nome = "Creme dental",Preco = 5.00M, TipoProduto = higiene, Qtde = 50 },
                new Produto() {Nome = "Fio dental",Preco = 8.02M, TipoProduto = higiene, Qtde = 40 },
                new Produto() {Nome = "Sabonete",Preco = 4.00M, TipoProduto = higiene, Qtde = 100 },
                new Produto() {Nome = "Desinfetante",Preco = 7.25M, TipoProduto = limpeza, Qtde = 35 },
                new Produto() {Nome = "Detergente",Preco = 2.35M, TipoProduto = limpeza, Qtde = 45 },
                new Produto() {Nome = "Telefone sem fio",Preco = 125.99M, TipoProduto = eletronico, Qtde = 120 },
                new Produto() {Nome = "Roteador",Preco = 235.95M, TipoProduto = eletronico, Qtde = 20 }
            };

            context.Produtos.AddRange(produtos);

            context.Usuarios.Add(new Usuario()
            {
                Nome = "Usuario",
                Email = "usuario@email.com",
                Senha = "12345".Encrypt()
            });


            context.SaveChanges();
        }
    }
}

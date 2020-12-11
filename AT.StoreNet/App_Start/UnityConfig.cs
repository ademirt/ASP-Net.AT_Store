using AT.StoreNet.Data.EF.Repositories;
using AT.StoreNet.Domain.Contracts.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AT.StoreNet
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IProdutoRepository, ProdutoRepositoryEF>();
            container.RegisterType<ITipoProdutoRepository, TipoProdutoRepositoryEF>();
            container.RegisterType<IUsuarioRepository, UsuarioRepositoryEF>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
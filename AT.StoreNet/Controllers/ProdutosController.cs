using AT.StoreNet.Data.EF.Repositories;
using AT.StoreNet.Domain.Contracts.Repositories;
using AT.StoreNet.ViewModels.Produtos.AddEdit.Maps;
using System.Web.Mvc;
using AT.StoreNet.ViewModels.Produtos.Index.Maps;
using AT.StoreNet.ViewModels.Produtos.AddEdit;

namespace AT.StoreNet.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        /*
         * DataContext --> _produtoRepository
         * readonly: para não levantar nova instancia
         * controle de estado para o EF para evitar o máximo de acesso a base dados
        
            private readonly ATStoreDataContext _produtoRepository = new ATStoreDataContext();

        */

        private readonly IProdutoRepository _produtoRepository;
        private readonly ITipoProdutoRepository _tipoProdutoRepository;


        public ProdutosController(IProdutoRepository produtoRepository
                                 , ITipoProdutoRepository tipoProdutoRepository)
        {
            _produtoRepository = produtoRepository;
            _tipoProdutoRepository = tipoProdutoRepository;
        }

        public ViewResult Index()
        {
            var produtos = _produtoRepository.Get().ToProdutoIndexVM();
            return View(produtos);
        }

        // GET
        [HttpGet]
        public ViewResult AddEdit(int? id)
        {
            var produto = new ProdutoAddEditVM();

            if (id != null)
            {
                produto = _produtoRepository.Get((int)id).ToProdutoAddEditVM(); //aplicando um cast...
            }

            ViewBag.TiposProdutos = _tipoProdutoRepository.Get();

            return View(produto);
        }

        // POST
        [HttpPost]
        public ActionResult AddEdit(ProdutoAddEditVM produtoVM)
        {
            var produto = produtoVM.ToProduto();

            //Validar model: se os campos obrigatórios foram preenchidos.
            if (ModelState.IsValid)
            {
                if (produto.Id == 0)
                {
                    _produtoRepository.Add(produto);
                }
                else
                {
                    _produtoRepository.Edit(produto);
                }

                //listar os dados: vai redirecionar para a "Action"  -> index 
                return RedirectToAction("Index");
            }

            ViewBag.TiposProdutos = _tipoProdutoRepository.Get();
            return View(produto);
        }

        public ActionResult Excluir(int id)
        {
            var produto = _produtoRepository.Get(id);
            if (produto == null)
            {
                return HttpNotFound();
            }

            _produtoRepository.Delete(produto);

            //???
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
        }
    }
}
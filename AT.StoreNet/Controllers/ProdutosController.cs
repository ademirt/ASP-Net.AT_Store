using AT.StoreNet.Data;
using AT.StoreNet.Models;
using System.Linq;
using System.Web.Mvc;

namespace AT.StoreNet.Controllers
{    
    public class ProdutosController : Controller
    {
        /*
         * DataContext --> _db
         * readonly: para não levantar nova instancia
         * controle de estado para o EF para evitar o máximo de acesso a base dados
        */
        private readonly ATStoreDataContext _db = new ATStoreDataContext();

        public ViewResult Index()
        {
            var produtos = _db.Produtos.ToList();
            return View(produtos);
        }

        // GET
        [HttpGet]
        public ViewResult AddEdit(int? id)
        {
            Produto produto = new Produto();

            if (id != null)
            {
                produto = _db.Produtos.Find(id);
            }

            ViewBag.TiposProdutos = _db.TipoProdutos.ToList();

            return View(produto);
        }

        // POST
        [HttpPost]
        public ActionResult AddEdit(Produto produto)
        {
            //Validar model: se os campos obrigatórios foram preenchidos.
            if (ModelState.IsValid)
            {
                if (produto.Id == 0)
                {
                    //datacontext _db inserir o produto digitado no formulário...
                    _db.Produtos.Add(produto);
                }
                else
                {
                    //datacontext _db atualizar o produto --> 'produto.Id'
                    _db.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                }

                //efetivar os dados (commit) na base...
                _db.SaveChanges();

                //listar os dados: vai redirecionar para a "Action"  -> index 
                return RedirectToAction("Index");
            }

            ViewBag.TiposProdutos = _db.TipoProdutos.ToList();
            return View(produto);
        }

        public ActionResult Excluir(int id)
        {
            var produto = _db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }

            _db.Produtos.Remove(produto);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
    }
}
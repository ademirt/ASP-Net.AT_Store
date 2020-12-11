using AT.StoreNet.Domain.Contracts.Repositories;
using AT.StoreNet.Domain.Helpers;
using AT.StoreNet.ViewModels.Conta.Login;
using System.Web.Mvc;
using System.Web.Security;

namespace AT.StoreNet.Controllers
{
    public class ContaController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ContaController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: Conta
        [HttpGet]
        public ActionResult Login(string returnURL)
        {
            var model = new LoginVM() { ReturnUrl = returnURL };
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            var usuario = _usuarioRepository.Get(model.Email);

            if (usuario == null)
            {
                ModelState.AddModelError("Email", "E-mail não localizado!!!");
            }
            else
            {
                if (usuario.Senha != model.Senha.Encrypt())
                {
                    ModelState.AddModelError("Senha", "Senha inválida!!!");
                }
            }

            if (ModelState.IsValid)
            {
                //Autenticar
                //Utilizar forms authentication com cookie
                FormsAuthentication.SetAuthCookie(model.Email, model.PermanecerLogado);

                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                return RedirectToAction("Index", "Home");

            }
            return View(model);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            _usuarioRepository.Dispose();
        }
    }
}
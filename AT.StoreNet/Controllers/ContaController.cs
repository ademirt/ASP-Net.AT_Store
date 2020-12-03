using AT.StoreNet.Data.EF;
using AT.StoreNet.Infra.Helpers;
using AT.StoreNet.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace AT.StoreNet.Controllers
{
    public class ContaController : Controller
    {
        private readonly ATStoreDataContext _db = new ATStoreDataContext();

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
            var usuario = _db.Usuarios.FirstOrDefault(u => u.Email.ToLower() == model.Email.ToLower());

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
            _db.Dispose();
        }
    }
}
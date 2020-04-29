using Payer.BusinessLayer;
using Payer.Entities;
using System.Web.Mvc;
using Payer.WebClasses;

namespace Payer.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Index(Login loginModel)
        {
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Login> blResultLogin = new BusinessLayerResult<Login>();
                LoginManager loginManager = new LoginManager();
                blResultLogin = loginManager.Login(loginModel);

                if (blResultLogin.BlResult != null)
                {
                    //Session["login"] = blResultLogin.BlResult;
                    CurrentSession.Set("login", blResultLogin.BlResult);
                    return RedirectToAction("Index", "Employee");
                }
                TempData["loginerror"] = "Username or password wrong!";
            }

            return View(loginModel);
        }

        public ActionResult Logout()
        {
            //if (Session["login"] != null)
            //{
            //    Session.RemoveAll();
            //}

            if (CurrentSession.Login != null)
            {
                CurrentSession.Clear();
            }

            return RedirectToAction("Index");
        }
    }
}
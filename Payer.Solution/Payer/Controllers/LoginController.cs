using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Payer.BusinessLayer;
using Payer.Entities;

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
                blResultLogin =  loginManager.Login(loginModel);
                TempData["loginerror"] = "Username or password wrong!";
                if (blResultLogin.BlResult != null)
                {
                    Session["login"] = blResultLogin.BlResult;
                    
                    return RedirectToAction("Index", "Employee");
                }
            }

            
            return View(loginModel);
        }
        public ActionResult Logout()
        {
            if (Session["login"] != null)
            {
                Session.RemoveAll();
            }

            return RedirectToAction("Index");
        }

    }
}
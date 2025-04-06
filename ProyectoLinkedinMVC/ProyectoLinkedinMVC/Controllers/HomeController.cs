using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoLinkedinMVC.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
        public ActionResult Administrador()
        {
            return View();
        }

        public ActionResult UsuarioNormal()
        {
            return View();
        }
    }
}
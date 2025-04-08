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

        public ActionResult UsuarioEmpresarial()
        {
            return View();
        }

        public ActionResult Empresa()
        {
            return View();
        }

        public ActionResult Experiencia()
        {
            return View();
        }

        public ActionResult FormacionAcademica()
        {
            return View();
        }

        public ActionResult Habilidades()
        {
            return View();
        }

        public ActionResult Mensaje()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View("~/Views/Login/Login.cshtml");
        }

    }
}
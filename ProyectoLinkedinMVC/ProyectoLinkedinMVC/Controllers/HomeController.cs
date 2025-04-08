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
        [Authorize(Roles = "Admin")]
        public ActionResult Administrador()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult UsuarioNormal()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult UsuarioEmpresarial()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Empresa()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Experiencia()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult FormacionAcademica()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
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
using Newtonsoft.Json;
using ProyectoLinkedinMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Extensions.Logging;

namespace ProyectoLinkedinMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        public ActionResult Comentario()
        {
            return View();
        }
        public ActionResult Mensaje()
        {
            return View();
        }
        public ActionResult Vacante()
        {
            return View();
        }
        public ActionResult Conexion()
        {
            return View();
        }
        public ActionResult Notificacion()
        {
            return View();
        }
        public ActionResult Reaccion()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View("~/Views/Login/Login.cshtml");
        }
        public ActionResult Crear()
        {
            return View();
        }

    }
}

using ProyectoLinkedinMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoLinkedinMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: /Login/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Correo, string Contrasena)
        {
            if (string.IsNullOrEmpty(Correo) || string.IsNullOrEmpty(Contrasena))
            {
                ViewBag.Error = "Todos los campos son obligatorios";
                return View();
            }

            using (var db = new AuthDbContext())
            {
                // Se busca el usuario que coincida con el correo y la contraseña ingresados
                var usuario = db.Usuarios.FirstOrDefault(u => u.Correo == Correo && u.Contrasena == Contrasena);

                if (usuario != null)
                {
                    FormsAuthentication.SetAuthCookie(usuario.Correo, false);
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Error = "Correo o contraseña incorrectos";
            return View();
        }



        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
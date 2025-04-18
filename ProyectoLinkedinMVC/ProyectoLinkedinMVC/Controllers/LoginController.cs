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
                var usuario = db.Usuarios.FirstOrDefault(u => u.Correo == Correo && u.Contrasena == Contrasena);

                if (usuario != null)
                {
                    string roles = "";
                    if (usuario is Administrador)
                    {
                        roles = "Admin";
                    }
                    else if (usuario is Usuario_Empresarial)
                    {
                        roles = "Empresarial";
                    }
                    else if (usuario is Usuario_Normal)
                    {
                        roles = "Normal";
                    }

                    var ticket = new FormsAuthenticationTicket(
                        1,
                        usuario.Id.ToString(), // Almacenar ID en lugar de Correo
                        DateTime.Now,
                        DateTime.Now.AddMinutes(30),
                        false,
                        roles,
                        FormsAuthentication.FormsCookiePath
                    );

                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                    // Cookie adicional con ID de usuario
                    var userCookie = new HttpCookie("UsuarioId", usuario.Id.ToString())
                    {
                        Expires = DateTime.Now.AddMinutes(30)
                    };

                    Response.Cookies.Add(authCookie);
                    Response.Cookies.Add(userCookie);

                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Error = "Correo o contraseña incorrectos";
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            // Eliminar cookie de usuario
            if (Request.Cookies["UsuarioId"] != null)
            {
                var userCookie = new HttpCookie("UsuarioId")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(userCookie);
            }

            return RedirectToAction("Login");
        }
    }
}
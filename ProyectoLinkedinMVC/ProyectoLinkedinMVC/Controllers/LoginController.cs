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
                // Buscar el usuario que coincida con el correo y la contraseña
                var usuario = db.Usuarios.FirstOrDefault(u => u.Correo == Correo && u.Contrasena == Contrasena);

                if (usuario != null)
                {
                    // Determinar el rol según el tipo de usuario
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

                    // Crear el ticket de autenticación que incluye el rol
                    var ticket = new FormsAuthenticationTicket(
                        1,
                        usuario.Correo,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(30), // duración del ticket
                        false,
                        roles, // aquí se almacena el rol en la propiedad UserData
                        FormsAuthentication.FormsCookiePath
                    );

                    // Encriptar y agregar el ticket como cookie
                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(authCookie);

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
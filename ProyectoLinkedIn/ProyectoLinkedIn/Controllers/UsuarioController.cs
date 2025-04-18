using ProyectoLinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace ProyectoLinkedIn.Controllers
{
    public class UsuarioController : ApiController
    {
        private DBContextProject db = new DBContextProject();
        /// <summary>
        /// Obtiene todos los elementos.
        /// </summary>
        /// <returns>Una lista de elementos.</returns>
        [HttpGet]
        [Route("api/usuarios")]
        public IHttpActionResult Get()
        {
            var usuarios = from usuario in db.Usuario
                           select new
                           {
                               Id = usuario.Id,
                               Nombre = usuario.Nombre,
                               Apellido = usuario.Apellido,
                               Telefono = usuario.Telefono,
                               Correo = usuario.Correo

                           };
            return Ok(usuarios);
        }

        /// <summary>
        /// Obtiene un usuario por su id.
        /// </summary>
        /// <returns>Un elemmento.</returns>
        public IHttpActionResult Get(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            var tipoUsuario = usuario.GetType().Name;
            var respuesta = new
            {
                Usuario = usuario,
                TipoUsuario = tipoUsuario
            };
            return Ok(respuesta);
        }
        
        /// <summary>
        /// Elimina un usuario por su id.
        /// </summary>
        /// <returns>Ejemplo de solicitud.</returns>
        public IHttpActionResult Delete(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return Ok(usuario);
        }
    }
}

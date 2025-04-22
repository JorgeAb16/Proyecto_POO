using ProyectoLinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoLinkedIn.Controllers
{
    public class UsuarioNormalController : ApiController
    {
        private DBContextProject db = new DBContextProject();
        /// <summary>
        /// Obtiene todos los Usuarios Normales.
        /// </summary>
        /// <returns>Una lista de elementos.</returns>
        
        public IEnumerable<Usuario> GetNormales()
        {
            return db.Usuario.OfType<Usuario_Normal>().ToList();
        }

        /// <summary>
        /// Agrega un Usuario Normal.
        /// </summary>
        /// <returns>Ejemplo de solicitud.</returns>
        
        public IHttpActionResult PostNormal(Usuario_Normal usuario)
        {
            db.Usuario.Add(usuario);
            db.SaveChanges();

            return Ok(usuario);
        }

        /// <summary>
        /// Modifica un Usuario Normal por su id.
        /// </summary>
        
        public IHttpActionResult PutNormal(Usuario_Normal usuario)
        {
            int id = usuario.Id;
            if (usuario == null)
            {
                return BadRequest("El usuario no puede ser nulo.");
            }
            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(usuario);
        }
        /// <summary>
        /// Obtiene un usuario por id.
        /// </summary>
        /// <returns>Un usuario.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        public IHttpActionResult Get(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
        /// <summary>
        /// Elimina un usuario por id.
        /// </summary>
        /// <returns>nada.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        public IHttpActionResult Delete(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return Ok(usuario);
        }
    }
}

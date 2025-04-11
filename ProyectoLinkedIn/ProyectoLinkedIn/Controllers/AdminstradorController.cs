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
    public class AdminstradorController : ApiController
    {
        private DBContextProject db = new DBContextProject();
        /// <summary>
        /// Obtiene todos los Administradores.
        /// </summary>
        /// <returns>Una lista de elementos.</returns>
        
        public IEnumerable<Usuario> GetAdmin()
        {
            return db.Usuario.OfType<Administrador>().ToList();
        }
        /// <summary>
        /// Agrega un Administrador.
        /// </summary>
        
        public IHttpActionResult PostAdministrador(Administrador administrador)
        {
            if (administrador == null)
            {
                return BadRequest("El administrador no puede ser nulo.");
            }

            db.Usuario.Add(administrador);
            db.SaveChanges();

            return Ok(administrador);
        }

        /// <summary>
        /// Modifica un Administrador por su id.
        /// </summary>
        /// <returns>Ejemplo de solicitud.</returns>
        
        public IHttpActionResult PutAdmin(Administrador administrador)
        {
            
            db.Entry(administrador).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(administrador);
        }

        
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
        /// Elimina un Administrador por ID.
        /// </summary>
        /// <returns>Un objeto Administrador.</returns>
        // DELETE: api/Administrador/5
        public IHttpActionResult Delete(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return Ok(usuario);
        }
    }
}

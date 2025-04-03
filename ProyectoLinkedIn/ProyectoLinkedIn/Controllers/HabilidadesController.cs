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
    public class HabilidadesController : ApiController
    {
        private DBContextProject db = new DBContextProject();
        /// <summary>
        /// Obtiene todas las Habilidades.
        /// </summary>
        /// <returns>Una lista de elementos.</returns>
        [HttpGet]
        [Route("api/GetHAbilidades")]
        public IEnumerable<Habilidades> GetHabilidades()
        {
            return db.Habilidades;
        }

        /// <summary>
        /// Agrega una Habilidad.
        /// </summary>
        /// <returns>Ejemplo de solicitud.</returns>
        
        [HttpPost]
        [Route("api/PostHabilidad")]
        public IHttpActionResult PostHabilidad(Habilidades habilidad)
        {
            if (habilidad == null)
            {
                return BadRequest("La habilidad no puede ser nula");

            }
            var usuario = db.Usuario.Find(habilidad.Usuario_Id);
            if (usuario == null)
            {
                return NotFound();
            }
            habilidad.Usuario_Id = usuario.Id;
            db.Habilidades.Add(habilidad);
            db.SaveChanges();

            return Ok(habilidad);
        }

        /// <summary>
        /// Modifica una Habilidad.
        /// </summary>
        [Route("api/PutHabilidad")]
        public IHttpActionResult PutHabilidad(Habilidades habilidad)
        {
            int id = habilidad.Id;
            if (habilidad == null)
            {
                return BadRequest("El usuario no puede ser nulo.");
            }
            var usuario = db.Usuario.Find(habilidad.Usuario_Id);
            if (usuario == null)
            {
                return NotFound();
            }
            habilidad.Usuario_Id = usuario.Id;
            db.Entry(habilidad).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(habilidad);
        }
        /// <summary>
        /// Obtiene una habilidad por su id.
        /// </summary>
        public IHttpActionResult Get(int id)
        {
            Habilidades habilidad = db.Habilidades.Find(id);
            if (habilidad == null)
            {
                return NotFound();
            }
            return Ok(habilidad);
        }
        /// <summary>
        /// Elimina una habilidad por su id.
        /// </summary>
        public IHttpActionResult Delete(int id)
        {
            Habilidades habilidad = db.Habilidades.Find(id);
            db.Habilidades.Remove(habilidad);
            db.SaveChanges();
            return Ok(habilidad);
        }
    }
}

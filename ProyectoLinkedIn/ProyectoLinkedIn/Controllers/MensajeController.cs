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
    public class MensajeController : ApiController
    {
        private DBContextProject db = new DBContextProject();
        /// <summary>
        /// Obtiene todos los Mensajes.
        /// </summary>
        /// <returns>Una lista de elementos.</returns>
        [HttpGet]
        [Route("api/GetMensaje")]
        public IEnumerable<Mensaje> GetNormales()
        {
            return db.Mensaje;
        }
        /// <summary>
        /// Agrega un Mensaje.
        /// </summary>
        [Route("api/PostMensaje")]
        public IHttpActionResult PostMensaje(Mensaje mensaje)
        {
            if (mensaje == null)
            {
                return BadRequest("El mensaje no puede ser nulo.");
            }

            var usuario1 = db.Usuario.Find(mensaje.Remitente_Id);
            if (usuario1 == null)
            {
                return BadRequest("El usuario especificado no existe.");
            }
            var usuario2 = db.Usuario.Find(mensaje.Destinatario_Id);
            if (usuario2 == null)
            {
                return BadRequest("El usuario especificado no existe.");
            }

            mensaje.Remitente_Id = usuario1.Id;
            mensaje.Destinatario_Id = usuario2.Id;
            db.Mensaje.Add(mensaje);
            db.SaveChanges();


            return Ok(mensaje);
        }

        /// <summary>
        /// Modifica un Administrador por su id.
        /// </summary>
        /// <returns>Ejemplo de solicitud.</returns>
        [Route("api/PutMensaje")]
        public IHttpActionResult PutMensaje(Mensaje mensaje)
        {
            int id = mensaje.Id;
            if (mensaje == null)
            {
                return BadRequest("El mensaje no puede ser nulo.");
            }
         
            var usuario1 = db.Usuario.Find(mensaje.Remitente_Id);
            if (usuario1 == null)
            {
                return BadRequest("El usuario especificado no existe.");
            }
            var usuario2 = db.Usuario.Find(mensaje.Destinatario_Id);
            if (usuario2 == null)
            {
                return BadRequest("El usuario especificado no existe.");
            }

            mensaje.Remitente_Id = usuario1.Id;
            mensaje.Destinatario_Id = usuario2.Id;
            db.Entry(mensaje).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(mensaje);
        }
        public IHttpActionResult Get(int id)
        {
            Mensaje mensaje = db.Mensaje.Find(id);
            if (mensaje == null)
            {
                return NotFound();
            }
            return Ok(mensaje);
        }
        public IHttpActionResult Delete(int id)
        {
            Mensaje mensaje = db.Mensaje.Find(id);
            db.Mensaje.Remove(mensaje);
            db.SaveChanges();
            return Ok(mensaje);
        }
    }
}

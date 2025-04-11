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

        public IHttpActionResult Get()
        {

            var mensajes = from mensaje in db.Mensaje
                              join usuario1 in db.Usuario on mensaje.Remitente_Id equals usuario1.Id
                              join usuario2 in db.Usuario on mensaje.Destinatario_Id equals usuario2.Id
                              select new
                              {
                                  Id = mensaje.Id,

                                  Remitente_Id = usuario1.Id,
                                  Destinatario_Id = usuario2.Id,
                                  Fechadeenvio = mensaje.Fechadeenvio,
                                  Contenido = mensaje.Contenido,
                                  Remitente = usuario1.Nombre,
                                  Destinatario = usuario2.Nombre
                              };

            return Ok(mensajes);
        }
        /// <summary>
        /// Agrega un Mensaje.
        /// </summary>

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

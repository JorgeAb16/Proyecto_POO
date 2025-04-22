using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProyectoLinkedIn.Models;

namespace ProyectoLinkedIn.Controllers
{

    public class NotificacionController : ApiController
    {
        private DBContextProject db = new DBContextProject();
        /// <summary>
        /// Obtiene todas las notificaciones.
        /// </summary>
        /// <returns>Una lista de  notificaciones.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Notificacion
        public IHttpActionResult Get()
        {
            var notificaciones = from notificacion in db.Notificacion
                           join usuario in db.Usuario on notificacion.DestinatarioId equals usuario.Id
                           select new
                           {
                               Id = notificacion.Id,
                               Mensaje = notificacion.Mensaje,
                               DestinatarioId = usuario.Id,
                               Destinatario = usuario.Nombre,
                               FechaEnvio = notificacion.Fechaenvio,
                           };
            return Ok(notificaciones);
        }
        /// <summary>
        /// Obtiene una notificacion por id.
        /// </summary>
        /// <returns>Una notificacion.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Notificacion/5
        public IHttpActionResult Get(int id)
        {
            var noti = db.Notificacion.Find(id);
            if (noti == null)
            {
                return NotFound();
            }
            return Ok(noti);
        }
        /// <summary>
        /// Añade una notificacion.
        /// </summary>
        /// <returns>Una notificacion.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Notificacion
        public IHttpActionResult Post(Notificacion notificacion)
        {
            db.Notificacion.Add(notificacion);
            db.SaveChanges();
            return Ok(notificacion);
        }
        /// <summary>
        /// Modifica una notificacion por id.
        /// </summary>
        /// <returns>Una notifcacion.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Notificacion/5
        public IHttpActionResult Put(Notificacion notificacionModificada)
        {
            int id = notificacionModificada.Id;
            db.Entry(notificacionModificada).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(notificacionModificada);
        }
        /// <summary>
        /// Elimina una notificacion.
        /// </summary>
        /// <returns>Una notifcacion.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/Notificacion/5
        public IHttpActionResult Delete(int id)
        {
            Notificacion notificacion = db.Notificacion.Find(id);
            db.Notificacion.Remove(notificacion);
            db.SaveChanges();
            return Ok(notificacion);
        }
    }
}
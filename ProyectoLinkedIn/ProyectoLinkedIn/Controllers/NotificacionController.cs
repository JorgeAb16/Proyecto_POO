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
        // GET: api/Notificacion
        public IEnumerable<Notificacion> Get()
        {
            return db.Notificacion;
        }

        // GET: api/Notificacion/5
        public IHttpActionResult Get(int id)
        {
            Notificacion notificacion = db.Notificacion.Find(id);
            if (notificacion == null)
            {
                return NotFound();
            }
            return Ok(notificacion);
        }

        // POST: api/Notificacion
        public IHttpActionResult Post(Notificacion notificacion)
        {
            db.Notificacion.Add(notificacion);
            db.SaveChanges();
            return Ok(notificacion);
        }

        // PUT: api/Notificacion/5
        public IHttpActionResult Put(int id, Notificacion notificacionModificada)
        {
            db.Entry(notificacionModificada).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(notificacionModificada);
        }

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

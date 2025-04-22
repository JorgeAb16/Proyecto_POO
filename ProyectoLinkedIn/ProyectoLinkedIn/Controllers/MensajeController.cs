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
        /// obtiene mensajes por fecha de envio descendente.
        /// </summary>
        /// <returns>Una lista de mensajes.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        [HttpGet]
        [Route("api/Mensaje/GetChat")]
        public IHttpActionResult GetChat()
        {
            try
            {
                var mensajesQuery = from mensaje in db.Mensaje
                                    join usuario1 in db.Usuario on mensaje.Remitente_Id equals usuario1.Id
                                    join usuario2 in db.Usuario on mensaje.Destinatario_Id equals usuario2.Id
                                    orderby mensaje.Fechadeenvio descending
                                    select new
                                    {
                                        Id = mensaje.Id,
                                        Remitente_Id = usuario1.Id,
                                        Destinatario_Id = usuario2.Id,
                                        Fechadeenvio = mensaje.Fechadeenvio,
                                        Contenido = mensaje.Contenido,
                                        Remitente = usuario1.Nombre,
                                        Destinatario = usuario2.Nombre,
                                         
                                    };

                var mensajes = mensajesQuery.ToList();

                var conversaciones = mensajes
                    .GroupBy(m => new
                    {
                        User1 = Math.Min(m.Remitente_Id, m.Destinatario_Id),
                        User2 = Math.Max(m.Remitente_Id, m.Destinatario_Id)
                    })
                    .Select(g => new
                    {
                        User1Id = g.Key.User1,
                        User2Id = g.Key.User2,
                        User1Name = g.First(m => m.Remitente_Id == g.Key.User1 || m.Destinatario_Id == g.Key.User1).Remitente_Id == g.Key.User1
                            ? g.First(m => m.Remitente_Id == g.Key.User1).Remitente
                            : g.First(m => m.Destinatario_Id == g.Key.User1).Destinatario,
                        User2Name = g.First(m => m.Remitente_Id == g.Key.User2 || m.Destinatario_Id == g.Key.User2).Remitente_Id == g.Key.User2
                            ? g.First(m => m.Remitente_Id == g.Key.User2).Remitente
                            : g.First(m => m.Destinatario_Id == g.Key.User2).Destinatario,
                        UltimoMensaje = g.OrderByDescending(m => m.Fechadeenvio).First(),
                        TotalMensajes = g.Count(),
                        Mensajes = g.OrderBy(m => m.Fechadeenvio).Select(m => new
                        {
                            m.Id,
                            m.Remitente_Id,
                            m.Destinatario_Id,
                            m.Fechadeenvio,
                            m.Contenido,
                            m.Remitente,
                            m.Destinatario,
                            EsRemitente = m.Remitente_Id == g.Key.User1
                        })
                    })
                    .OrderByDescending(c => c.UltimoMensaje.Fechadeenvio)
                    .ToList();

                return Ok(new
                {
                    Success = true,
                    Conversaciones = conversaciones,
                    TotalConversaciones = conversaciones.Count
                });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new
                {
                    Success = false,
                    Message = "Error al obtener los mensajes",
                    Error = ex.Message
                });
            }
        }
        /// <summary>
        /// Añade un mensaje.
        /// </summary>
        /// <returns>Una mensaje.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        [HttpPost]
        [Route("api/Mensaje/Send")]
        public IHttpActionResult Send([FromBody] Mensaje mensaje)
        {
            try
            {
                mensaje.Fechadeenvio = DateTime.Now;
                db.Mensaje.Add(mensaje);
                db.SaveChanges();

                return Ok(new
                {
                    Success = true,
                    Message = new
                    {
                        mensaje.Id,
                        mensaje.Remitente_Id,
                        mensaje.Destinatario_Id,
                        mensaje.Fechadeenvio,
                        mensaje.Contenido
                    }
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
        /// Modifica un Mensaje por su id.
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
        /// <summary>
        /// Obtiene un mensaje por id.
        /// </summary>
        /// <returns>Un mensaje.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        public IHttpActionResult Get(int id)
        {
            Mensaje mensaje = db.Mensaje.Find(id);
            if (mensaje == null)
            {
                return NotFound();
            }
            return Ok(mensaje);
        }
        /// <summary>
        /// Elimina un mensaje.
        /// </summary>
        /// <returns>Un mensaje.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        public IHttpActionResult Delete(int id)
        {
            Mensaje mensaje = db.Mensaje.Find(id);
            db.Mensaje.Remove(mensaje);
            db.SaveChanges();
            return Ok(mensaje);
        }

    }
}

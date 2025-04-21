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
    public class PublicacionController : ApiController
    {
        private DBContextProject db = new DBContextProject();
        [HttpGet]
        [Route("api/Publicaciones")]
        public IHttpActionResult Get()
        {
            var query = from publicacion in db.Publicacion
                        join usuario in db.Usuario on publicacion.UsuarioId equals usuario.Id
                        select new
                        {
                            Titulo = publicacion.Titulo,
                            Id = publicacion.Id,
                            Contenido = publicacion.Contenido,
                            FechaPublicacion = publicacion.Fechapublicacion,
                            UsuarioId = publicacion.UsuarioId,
                            UsuarioNombre = usuario.Nombre,

                            Comentarios = (from comentario in db.Comentario
                                           join usuario1 in db.Usuario on comentario.UsuarioId equals usuario1.Id
                                           where comentario.PublicacionId == publicacion.Id
                                           select new
                                           {
                                               Id = comentario.Id,
                                               Por = usuario1.Nombre + " " + usuario1.Apellido,
                                               Contenido = comentario.Contenido,
                                               Fecha = comentario.Fechapublicacion,
                                               Reacciones = (from reaccion in db.Reaccion
                                                             join usuario2 in db.Usuario on reaccion.UsuarioID equals usuario2.Id
                                                             where reaccion.ComentarioID == comentario.Id
                                                             select new
                                                             {
                                                                 Por = usuario2.Nombre + " " + usuario2.Apellido,
                                                                 Contenido = reaccion.Contenido,
                                                                 Nombre = reaccion.NombreReaccion
                                                             })
                                           }),

                            Reacciones = (from reaccion in db.Reaccion
                                          join usuario2 in db.Usuario on reaccion.UsuarioID equals usuario2.Id
                                          where reaccion.PublicacionID == publicacion.Id 
                                          select new
                                          {
                                              Por = usuario2.Nombre + " " + usuario2.Apellido,
                                              Contenido = reaccion.Contenido,
                                              Nombre = reaccion.NombreReaccion
                                          })
                        };

            return Ok(query);
        }


        public IHttpActionResult Get(int id)
        {
            var publica = db.Publicacion.Find(id);
            if (publica == null)
            {
                return NotFound();
            }
            return Ok(publica);
        }


        [HttpPost]
        public IHttpActionResult Post([FromBody] Publicacion publicacion)
        {
            try
            {
                if (publicacion.UsuarioId <= 0)
                    return BadRequest("ID de usuario no válido");

                if (string.IsNullOrEmpty(publicacion.Titulo))
                    return BadRequest("El título es requerido");

                if (string.IsNullOrEmpty(publicacion.Contenido))
                    return BadRequest("El contenido es requerido");

                publicacion.Fechapublicacion = DateTime.Now;

                db.Publicacion.Add(publicacion);
                db.SaveChanges();

                return Ok(publicacion);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Put(Publicacion publicacionModificada)
        {
            int id = publicacionModificada.Id;
            db.Entry(publicacionModificada).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(publicacionModificada);
        }

        public IHttpActionResult Delete(int id)
        {
            Publicacion publicacion = db.Publicacion.Find(id);
            db.Publicacion.Remove(publicacion);
            db.SaveChanges();
            return Ok(publicacion);

        }

    }
}

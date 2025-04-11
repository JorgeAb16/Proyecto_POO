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
                            UsuarioNombre = usuario.Nombre,

                            Comentarios = (from comentario in db.Comentario
                                           join usuario1 in db.Usuario on comentario.UsuarioId equals usuario1.Id
                                           where comentario.PublicacionId == publicacion.Id
                                           select new
                                           {
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
            var query = from publicacion in db.Publicacion
                        join usuario in db.Usuario on publicacion.UsuarioId equals usuario.Id
                        where publicacion.Id == id
                        select new
                        {
                            Titulo = publicacion.Titulo,
                            Id = publicacion.Id,
                            Contenido = publicacion.Contenido,
                            FechaPublicacion = publicacion.Fechapublicacion,
                            UsuarioNombre = usuario.Nombre,

                            Comentarios = (from comentario in db.Comentario
                                           join publicacion1 in db.Publicacion on comentario.PublicacionId equals publicacion1.Id
                                           join usuario1 in db.Usuario on comentario.UsuarioId equals usuario1.Id
                                           where comentario.PublicacionId == publicacion1.Id
                                           select new
                                           {
                                               Por = usuario1.Nombre + " " + usuario1.Apellido,
                                               Contenido = comentario.Contenido,
                                               Fecha = comentario.Fechapublicacion,
                                               Reacciones = (from reacciones in db.Reaccion
                                                             join usuario2 in db.Usuario on reacciones.UsuarioID equals usuario2.Id
                                                             where reacciones.ComentarioID == comentario.Id
                                                             select new
                                                             {
                                                                 Por = usuario2.Nombre + " " + usuario2.Apellido,
                                                                 Contenido = reacciones.Contenido,
                                                                 Nombre = reacciones.NombreReaccion

                                                             })
                                           }),

                            Reacciones = (from reacciones1 in db.Reaccion
                                          join publicacion1 in db.Publicacion on reacciones1.PublicacionID equals publicacion1.Id
                                          join usuario2 in db.Usuario on reacciones1.UsuarioID equals usuario2.Id
                                          where reacciones1.PublicacionID == publicacion1.Id
                                          select new
                                          {
                                              Por = usuario2.Nombre + " " + usuario2.Apellido,
                                              Contenido = reacciones1.Contenido,
                                              Nombre = reacciones1.NombreReaccion

                                          })

                        };

            return Ok(query);
        }

        public IHttpActionResult Post(Publicacion publicacion)
        {
            db.Publicacion.Add(publicacion);
            db.SaveChanges();
            return Ok(publicacion);
        }

        public IHttpActionResult Put(int id, Publicacion publicacionModificada)
        {
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

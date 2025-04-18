using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProyectoLinkedIn.Models;

namespace ProyectoLinkedIn.Controllers
{
    public class ComentarioController : ApiController
    {
        private DBContextProject db = new DBContextProject();
        // GET: api/Comentario
        public IHttpActionResult Get()
        {

            var comentarios = from comentario in db.Comentario
                             join usuario in db.Usuario on comentario.UsuarioId equals usuario.Id
                             join publicacion in db.Publicacion on comentario.PublicacionId equals publicacion.Id
                             select new
                             {
                                 Id = comentario.Id,

                                 UsuarioId = usuario.Id,
                                 UsuarioNombre = usuario.Nombre,

                                 publicacionId = publicacion.Id,
                                 publicacionTitulo = publicacion.Titulo,

                                 Contenido = comentario.Contenido,
                                 FechaPublicacion = comentario.Fechapublicacion,
                             };

            return Ok(comentarios);
        }

        // GET: api/Comentario/5
        public IHttpActionResult Get(int id)
        {
            var comentarios = from comentario in db.Comentario
                              join usuario in db.Usuario on comentario.UsuarioId equals usuario.Id
                              join publicacion in db.Publicacion on comentario.PublicacionId equals publicacion.Id
                              where comentario.Id == id
                              select new
                              {
                                  ComentarioId = comentario.Id,

                                  IdUsuario = usuario.Id,
                                  UsuarioNombre = usuario.Nombre,

                                  publicacionId = publicacion.Id,
                                  publicacionTitulo = publicacion.Titulo,

                                  Contenido = comentario.Contenido,
                                  FechaPublicacion = comentario.Fechapublicacion,
                              };

            return Ok(comentarios);
        }

        // POST: api/Comentario
        public IHttpActionResult Post(Comentario comentario)
        {
            comentario.Fechapublicacion = DateTime.Now;
            db.Comentario.Add(comentario);
            db.SaveChanges();
            return Ok(comentario);
        }

        // PUT: api/Comentario/5
        public IHttpActionResult Put(int id, Comentario comentarioModificado)
        {
            db.Entry(comentarioModificado).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(comentarioModificado);
        }

        // DELETE: api/Comentario/5
        public IHttpActionResult Delete(int id)
        {
            Comentario comentario = db.Comentario.Find(id);
            db.Comentario.Remove(comentario);
            db.SaveChanges();
            return Ok(comentario);

        }
    }
}

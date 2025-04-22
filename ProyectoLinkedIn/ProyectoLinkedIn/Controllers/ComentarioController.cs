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
        /// <summary>
        /// Obtiene todos los comentarios.
        /// </summary>
        /// <returns>Objetos tipo comentario.</returns>
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
        /// <summary>
        /// Obtiene un comentario por id.
        /// </summary>
        /// <returns>Un comentario.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Comentario/5
        public IHttpActionResult Get(int id)
        {
            Comentario coment = db.Comentario.Find(id);
            if (coment == null)
            {
                return NotFound();
            }
            return Ok(coment);
        }
        /// <summary>
        /// Añade un comentario.
        /// </summary>
        /// <returns>Un comentario.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Comentario
        public IHttpActionResult Post(Comentario comentario)
        {
            comentario.Fechapublicacion = DateTime.Now;
            db.Comentario.Add(comentario);
            db.SaveChanges();
            return Ok(comentario);
        }
        /// <summary>
        /// Modifica un comentario.
        /// </summary>
        /// <returns>Un comentario.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Comentario/5
        public IHttpActionResult Put(Comentario comentarioModificado)
        {
            int id = comentarioModificado.Id;
            db.Entry(comentarioModificado).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(comentarioModificado);
        }
        /// <summary>
        /// Elimina un comentario.
        /// </summary>
        /// <returns>Un comentario.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
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

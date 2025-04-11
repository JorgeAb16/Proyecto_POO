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
    public class ReaccionController : ApiController
    {
        private DBContextProject db = new DBContextProject();


        /// <summary>
        /// Obtiene todas las Reacciones.
        /// </summary>
        /// <returns>Una lista de Reacciones.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Reaccion
        public IHttpActionResult Get()
        {

            var reacciones = from reaccion in db.Reaccion
                             join comentario in db.Comentario on reaccion.ComentarioID equals comentario.Id
                             join usuario in db.Usuario on reaccion.UsuarioID equals usuario.Id
                             join publicacion in db.Publicacion on reaccion.PublicacionID equals publicacion.Id
                             select new
                             {
                                 Id = reaccion.Id,
                                 Contenido = reaccion.Contenido,
                                 NombreReaccion = reaccion.NombreReaccion,
                                 ComentarioID = comentario.Id,
                                 
                                 UsuarioID = usuario.Id,
                                 Nombre = usuario.Nombre,

                                 publicacionID = publicacion.Id,
                                 publicacionTitulo = publicacion.Titulo,
                             };

            return Ok(reacciones);
        }

        /// <summary>
        /// Obtiene una Reaccion por ID.
        /// </summary>
        /// <returns>Un objeto Reaccion.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Reaccion/5
        public IHttpActionResult Get(int id)
        {
            var reacciones = from reaccion in db.Reaccion
                             join comentario in db.Comentario on reaccion.ComentarioID equals comentario.Id
                             join usuario in db.Usuario on reaccion.UsuarioID equals usuario.Id
                             join publicacion in db.Publicacion on reaccion.PublicacionID equals publicacion.Id
                             where reaccion.Id == id
                             select new
                             {
                                 ReaccionId = reaccion.Id,
                                 ReaccionContenido = reaccion.Contenido,

                                 ComentarioId = comentario.Id,

                                 IdUsuario = usuario.Id,
                                 UsuarioNombre = usuario.Nombre,

                                 publicacionId = publicacion.Id,
                                 publicacionTitulo = publicacion.Titulo,
                             };

            return Ok(reacciones);

        }

        /// <summary>
        /// Inserta una Reaccion.
        /// </summary>
        /// <returns>Un objeto Reaccion.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Reaccion
        public IHttpActionResult Post(Reaccion reaccion)
        {
            db.Reaccion.Add(reaccion);
            db.SaveChanges();
            return Ok(reaccion);
        }

        /// <summary>
        /// Modifica una Reaccion por ID.
        /// </summary>
        /// <returns>Un objeto Reaccion.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Reaccion/5
        public IHttpActionResult Put(int id, Reaccion reaccionM)
        {

            db.Entry(reaccionM).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(reaccionM);
        }


        /// <summary>
        /// Elimina una Reaccion por ID.
        /// </summary>
        /// <returns>Un objeto Reaccion.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/Reaccion/5
        public IHttpActionResult Delete(int id)
        {
            Reaccion reaccion = db.Reaccion.Find(id);
            db.Reaccion.Remove(reaccion);
            db.SaveChanges();
            return Ok(reaccion);
        }
    }
}

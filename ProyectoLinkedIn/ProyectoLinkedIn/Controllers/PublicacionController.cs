using ProyectoLinkedIn.Models;
using System;
using System.Collections.Generic;
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
                                    Id= publicacion.Id,
                                    Contenido = publicacion.Contenido,
                                    FechaPublicacion = publicacion.Fechapublicacion,
                                    UsuarioNombre = usuario.Nombre,

                                    Comentarios =( from comentario in db.Comentario 
                                                  join publicacion1 in db.Publicacion on comentario.PublicacionId equals publicacion1.Id
                                                  join usuario1 in db.Usuario on comentario.UsuarioId equals usuario1.Id
                                                  where comentario.PublicacionId == publicacion1.Id
                                                  select new
                                                  {
                                                      Por = usuario1.Nombre+" "+usuario1.Apellido,
                                                      Contenido = comentario.Contenido,
                                                      Fecha = comentario.Fechapublicacion
                                                  })
                                                  
                                };

            return Ok(query);
        }

    }
}

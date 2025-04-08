using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProyectoLinkedIn.Models;

namespace ProyectoLinkedIn.Controllers
{
    public class VacanteController : ApiController
    {
        private DBContextProject db = new DBContextProject();
        // GET: api/Vacante
        public IHttpActionResult Get()
        {
            var vacantes = from vacante in db.Vacante
                              join empresa in db.Empresa on vacante.EmpresaId equals empresa.Id
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

        // GET: api/Vacante/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Vacante
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Vacante/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Vacante/5
        public void Delete(int id)
        {
        }
    }
}

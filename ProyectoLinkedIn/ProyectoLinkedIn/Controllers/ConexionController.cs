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
    public class ConexionController : ApiController
    {
        private DBContextProject db = new DBContextProject();
        /// <summary>
        /// Obtiene todas las Conexiones.
        /// </summary>
        /// <returns>Una lista de Conexiones.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Conexion
        public IHttpActionResult Get()
        {

            var conexiones = from conexion in db.Conexion
                           join usuario1 in db.Usuario on conexion.Usuario1 equals usuario1.Id
                           join usuario2 in db.Usuario on conexion.Usuario2 equals usuario2.Id
                           select new
                           {
                               Id = conexion.Id,

                               Usuario1 = usuario1.Id,
                               Usuario2 = usuario2.Id,
                
                               Nombre1 = usuario1.Nombre,
                               Nombre2 = usuario2.Nombre,

                               _Conexion = conexion._Conexion
                           };

            return Ok(conexiones);
        }
        /// <summary>
        /// Obtiene todos los amigos filtrando por usuario.
        /// </summary>
        /// <returns>Una lista de Usuarios.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        [HttpGet]
        [Route("api/Conexion/GetAmigosPorUsuario")]
        public IHttpActionResult GetAmigosPorUsuario(int usuarioId)
        {
                var amigos = (from conexion in db.Conexion
                              join usuario1 in db.Usuario on conexion.Usuario1 equals usuario1.Id
                              join usuario2 in db.Usuario on conexion.Usuario2 equals usuario2.Id
                              where conexion._Conexion == "amigos" &&
                                    (conexion.Usuario1 == usuarioId || conexion.Usuario2 == usuarioId)
                              select conexion.Usuario1 == usuarioId ?
                                  new
                                  {
                                      Id = usuario2.Id,
                                      Nombre = usuario2.Nombre,
                                      Apellido = usuario2.Apellido,
                                      NombreCompleto = usuario2.Nombre + " " + usuario2.Apellido,
                                      TipoConexion = conexion._Conexion,
                                   
                                  } :
                                  new
                                  {
                                      Id = usuario1.Id,
                                      Nombre = usuario1.Nombre,
                                      Apellido = usuario1.Apellido,
                                      NombreCompleto = usuario1.Nombre + " " + usuario1.Apellido,
                                      TipoConexion = conexion._Conexion,
                                     
                                  });

                return Ok(amigos);
        }
        /// <summary>
        /// Obtiene una conexion por id.
        /// </summary>
        /// <returns>Una conexion.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Conexion/5
        public IHttpActionResult Get(int id)
        {
            Conexion conexion = db.Conexion.Find(id);
            if (conexion == null)
            {
                return NotFound();
            }
            return Ok(conexion);
        }
        /// <summary>
        /// Añade una conexion.
        /// </summary>
        /// <returns>Una conexion.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Conexion
        public IHttpActionResult Post(Conexion conexion)
        {
            if (conexion == null)
            {
                return BadRequest("La conexion no se logro hacer");
            }

            var usuario1 = db.Usuario.Find(conexion.Usuario1);
            if (usuario1 == null)
            {
                return BadRequest("El usuario especificado no existe.");
            }
            var usuario2 = db.Usuario.Find(conexion.Usuario2);
            if (usuario2 == null)
            {
                return BadRequest("El usuario especificado no existe.");
            }

            conexion.Usuario1 = usuario1.Id;
            conexion.Usuario2 = usuario2.Id;
            conexion._Conexion = "amigos";
            db.Conexion.Add(conexion);
            db.SaveChanges();


            return Ok(conexion);
        }
        /// <summary>
        /// Añade una conexion.
        /// </summary>
        /// <returns>Una conexion.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Conexion/5
        public IHttpActionResult Put(Conexion conexion)
        {
            int id = conexion.Id;
            if (conexion == null)
            {
                return BadRequest("La conexion no se logró.");
            }

            var usuario1 = db.Usuario.Find(conexion.Usuario1);
            if (usuario1 == null)
            {
                return BadRequest("El usuario especificado no existe.");
            }
            var usuario2 = db.Usuario.Find(conexion.Usuario2);
            if (usuario2 == null)
            {
                return BadRequest("El usuario especificado no existe.");
            }

            conexion.Usuario1 = usuario1.Id;
            conexion.Usuario2 = usuario2.Id;
            db.Entry(conexion).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(conexion);
        }
        /// <summary>
        /// Elimina una conexion.
        /// </summary>
        /// <returns>Una conexion.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/Conexion/5
        public IHttpActionResult Delete(int id)
        {
            Conexion conexion = db.Conexion.Find(id);
            db.Conexion.Remove(conexion);
            db.SaveChanges();
            return Ok(conexion);
        }
    }
}

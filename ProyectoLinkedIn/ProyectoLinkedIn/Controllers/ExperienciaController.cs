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
    public class ExperienciaController : ApiController
    {

        private DBContextProject db = new DBContextProject();


        /// <summary>
        /// Obtiene todas las Experiencias.
        /// </summary>
        /// <returns>Una lista de Experiencias.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Experiencia
        public IHttpActionResult Get()
        {
            var experiencias = from experiencia in db.Experiencia
                               join usuario in db.Usuario on experiencia.UsuarioID equals usuario.Id
                               select new
                               {
                                   ExperienciaId = experiencia.Id,
                                   UsuarioId = usuario.Id,
                                   UsuarioNombre = usuario.Nombre,
                                   Empresa = experiencia.Empresa,
                                   Cargo = experiencia.Cargo,
                                   FechaInicio = experiencia.Fecha_inicio,
                                   FechaFin = experiencia.Fecha_fin
                               };
            return Ok(experiencias);
        }

        /// <summary>
        /// Obtiene una experiencia por ID.
        /// </summary>
        /// <returns>Un objeto Experiencia.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Experiencia/5
        public IHttpActionResult Get(int id)
        {

            var experiencias = from experiencia in db.Experiencia
                               join usuario in db.Usuario on experiencia.UsuarioID equals usuario.Id
                               where experiencia.Id == id
                               select new
                               {
                                   ExperienciaId = experiencia.Id,
                                   UsuarioId = usuario.Id,
                                   UsuarioNombre = usuario.Nombre,
                                   Empresa = experiencia.Empresa,
                                   Cargo = experiencia.Cargo,
                                   FechaInicio = experiencia.Fecha_inicio,
                                   FechaFin = experiencia.Fecha_fin
                               };
            return Ok(experiencias);
        }

        /// <summary>
        /// Inserta una Experiencia.
        /// </summary>
        /// <returns>Un objeto Experiencia.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Experiencia
        public IHttpActionResult Post(Experiencia experiencia)
        {
            db.Experiencia.Add(experiencia);
            db.SaveChanges();
            return Ok(experiencia);
        }

        /// <summary>
        /// Modifica un objeto Experiencia.
        /// </summary>
        /// <returns>Un objeto Experiencia.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Experiencia/5
        public IHttpActionResult Put(int id, Experiencia experienciaM)
        {
            db.Entry(experienciaM).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(experienciaM);
        }

        /// <summary>
        /// Elimina un objeto Experiencia.
        /// </summary>
        /// <returns>Un objeto Experiencia.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/Experiencia/5
        public IHttpActionResult Delete(int id)
        {
            Experiencia experiencia = db.Experiencia.Find(id);
            db.Experiencia.Remove(experiencia);
            db.SaveChanges();
            return Ok(experiencia);
        }
    }
}

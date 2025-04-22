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
    public class VacanteController : ApiController
    {
        private DBContextProject db = new DBContextProject();
        /// <summary>
        /// Obtiene todas las vacantes.
        /// </summary>
        /// <returns>una lista de vacantes.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Vacante
        public IHttpActionResult Get()
        {
            var vacantes = from vacante in db.Vacante
                               join empresa in db.Empresa on vacante.EmpresaId equals empresa.Id
                               select new
                               {
                                   Id = vacante.Id,
                                   Titulo = vacante.Titulo,
                                   Descripcion = vacante.Descripcion,
                                   Requisitos = vacante.Requisitos,
                                   Salario = vacante.Salario,
                                   Ubicacion = vacante.Ubicacion,
                                   EmpresaId = empresa.Id,
                                   Empresa = empresa.Nombre,
                               };
            return Ok(vacantes);
        }
        /// <summary>
        /// Obtiene una vacante por id.
        /// </summary>
        /// <returns>una vacante.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Vacante/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var vacante = db.Vacante.Find(id);
            if (vacante == null)
            {
                return NotFound();
            }
            return Ok(vacante);
        }
        /// <summary>
        /// Añade una vacante.
        /// </summary>
        /// <returns>una vacante.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Vacante
        public IHttpActionResult Post(Vacante vacante)
        {
            db.Vacante.Add(vacante);
            db.SaveChanges();
            return Ok(vacante);
        }
        /// <summary>
        /// Modifica una vacante por id.
        /// </summary>
        /// <returns>una vacante.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Vacante/5
        public IHttpActionResult Put(Vacante vacanteModificada)
        {
            int id = vacanteModificada.Id;
            db.Entry(vacanteModificada).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(vacanteModificada);
        }
        /// <summary>
        /// Elimina una vacante por id.
        /// </summary>
        /// <returns>nada.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/Vacante/5
        public IHttpActionResult Delete(int id)
        {
            Vacante vacante = db.Vacante.Find(id);
            db.Vacante.Remove(vacante);
            db.SaveChanges();
            return Ok(vacante);
        }
    }
}

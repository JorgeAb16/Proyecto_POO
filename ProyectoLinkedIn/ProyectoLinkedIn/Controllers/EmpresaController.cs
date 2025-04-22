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
    public class EmpresaController : ApiController
    {
        private DBContextProject db = new DBContextProject();
        /// <summary>
        /// Obtiene todas las empresas.
        /// </summary>
        /// <returns>Una lista de empresa.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Empresa
        public IEnumerable<Empresa> Get()
        {
            return db.Empresa;
        }
        /// <summary>
        /// Obtiene una empresa por id.
        /// </summary>
        /// <returns>Una empresa.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Empresa/5
        public IHttpActionResult Get(int id)
        {
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return Ok(empresa);
        }
        /// <summary>
        /// Añade una empresa.
        /// </summary>
        /// <returns>Una empresa.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Empresa
        public IHttpActionResult Post(Empresa empresa)
        {
            db.Empresa.Add(empresa);
            db.SaveChanges();
            return Ok(empresa);
        }
        /// <summary>
        /// Modifica una emmpresa.
        /// </summary>
        /// <returns>Una empresa.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Empresa/5
        public IHttpActionResult Put(Empresa empresaModificada)
        {
            int id = empresaModificada.Id;
            db.Entry(empresaModificada).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(empresaModificada);
        }
        /// <summary>
        /// Elimina una empresa.
        /// </summary>
        /// <returns>Una empresa.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/Empresa/5
        public IHttpActionResult Delete(int id)
        {
            Empresa empresa = db.Empresa.Find(id);
            db.Empresa.Remove(empresa);
            db.SaveChanges();
            return Ok(empresa);
        }
    }
}

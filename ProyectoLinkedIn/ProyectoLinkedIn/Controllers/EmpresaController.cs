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
        // GET: api/Empresa
        public IEnumerable<Empresa> Get()
        {
            return db.Empresa;
        }

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

        // POST: api/Empresa
        public IHttpActionResult Post(Empresa empresa)
        {
            db.Empresa.Add(empresa);
            db.SaveChanges();
            return Ok(empresa);
        }

        // PUT: api/Empresa/5
        public IHttpActionResult Put(int id, Empresa empresaModificada)
        {
            db.Entry(empresaModificada).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(empresaModificada);
        }

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

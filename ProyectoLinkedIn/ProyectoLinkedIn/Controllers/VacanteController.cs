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

        // GET: api/Vacante/5
        public IHttpActionResult Get(int id)
        {
            var vacantes = from vacante in db.Vacante
                           join empresa in db.Empresa on vacante.EmpresaId equals empresa.Id
                           where vacante.Id == id
                           select new
                           {
                               VacanteId = vacante.Id,
                               Titulo = vacante.Titulo,
                               Descripcion = vacante.Descripcion,
                               Requisitos = vacante.Requisitos,
                               Salario = vacante.Salario,
                               Ubicacion = vacante.Ubicacion,
                               Empresa = empresa.Nombre,
                           };
            return Ok(vacantes);
        }

        // POST: api/Vacante
        public IHttpActionResult Post(Vacante vacante)
        {
            db.Vacante.Add(vacante);
            db.SaveChanges();
            return Ok(vacante);
        }

        // PUT: api/Vacante/5
        public IHttpActionResult Put(int id, Vacante vacanteModificada)
        {
            db.Entry(vacanteModificada).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(vacanteModificada);
        }

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

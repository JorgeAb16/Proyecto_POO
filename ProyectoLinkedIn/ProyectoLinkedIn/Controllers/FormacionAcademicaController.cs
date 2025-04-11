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
    public class FormacionAcademicaController : ApiController
    {

        private DBContextProject db = new DBContextProject();

        /// <summary>
        /// Obtiene todas las Formaciones.
        /// </summary>
        /// <returns>Una lista de Experiencias.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/FormacionAcademica
        public IHttpActionResult Get()
        {
            var formaciones = from formacion in db.FormacionAcademica
                              join usuario in db.Usuario on formacion.UsuarioID equals usuario.Id
                              select new
                              {
                                  Id = formacion.Id,
                                  UsuarioId = usuario.Id,
                                  UsuarioNombre = usuario.Nombre,
                                  Titulo = formacion.Titulo,
                                  Grado = formacion.Grado,
                                  Descripcion = formacion.Descripcion,
                                  FechaAdquisicion = formacion.Fecha_adquisicion,
                                  InstitucionEducativa = formacion.Institucion_educativa
                              };
            return Ok(formaciones);
        }

        /// <summary>
        /// Obtiene una formacion por ID.
        /// </summary>
        /// <returns>Un objeto FormacionAcademica.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/FormacionAcademica/5
        public IHttpActionResult Get(int id)
        {

            var formaciones = from formacion in db.FormacionAcademica
                              join usuario in db.Usuario on formacion.UsuarioID equals usuario.Id
                              where formacion.Id == id
                              select new
                              {
                                  Id = formacion.Id,
                                  UsuarioId = usuario.Id,
                                  UsuarioNombre = usuario.Nombre,
                                  Titulo = formacion.Titulo,
                                  Grado = formacion.Grado,
                                  Descripcion = formacion.Descripcion,
                                  FechaAdquisicion = formacion.Fecha_adquisicion,
                                  InstitucionEducativa = formacion.Institucion_educativa
                              };
            return Ok(formaciones);
        }

        /// <summary>
        /// Inserta una FormacionAcademica.
        /// </summary>
        /// <returns>Un objeto FormacionAcademica.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/FormacionAcademica
        public IHttpActionResult Post(Formacion_Academica formacionAcademica)
        {
            db.FormacionAcademica.Add(formacionAcademica);
            db.SaveChanges();
            return Ok(formacionAcademica);
        }

        /// <summary>
        /// Modifica una FormacionAcademica.
        /// </summary>
        /// <returns>Un objeto FormacionAcademica.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/FormacionAcademica/5
        public IHttpActionResult Put(int id, Formacion_Academica formacionM)
        {
            db.Entry(formacionM).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(formacionM);
        }

        /// <summary>
        /// Elimina una FormacionAcademica.
        /// </summary>
        /// <returns>Un objeto FormacionAcademica.</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/FormacionAcademica/5
        public IHttpActionResult Delete(int id)
        {
            Formacion_Academica formacionAcademica = db.FormacionAcademica.Find(id);
            db.FormacionAcademica.Remove(formacionAcademica);
            db.SaveChanges();
            return Ok(formacionAcademica);
        }
    }
}

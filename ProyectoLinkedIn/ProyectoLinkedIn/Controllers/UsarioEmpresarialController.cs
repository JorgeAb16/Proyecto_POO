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
    public class UsarioEmpresarialController : ApiController
    {
        private DBContextProject db = new DBContextProject();

        /// <summary>
        /// Obtiene todos los Usuarios Empresariales.
        /// </summary>
        /// <returns>Una lista de elementos.</returns>
        [HttpGet]
        [Route("api/GetEmpresarial")]
        public IEnumerable<Usuario> GetEmpresarial()
        {
            return db.Usuario.OfType<Usuario_Empresarial>().ToList();
        }
        /// <summary>
        /// Agrega un Usuario Empresarial.
        /// </summary>
        [Route("api/PostEmpresarial")]
        public IHttpActionResult PostEmpresarial(Usuario_Empresarial usuario)
        {
            if (usuario == null)
            {
                return BadRequest("El usuario no puede ser nulo.");
            }

            var empresa = db.Empresa.Find(usuario.Empresa_Id);
            if (empresa == null)
            {
                return BadRequest("La empresa especificada no existe.");
            }

            usuario.Empresa = empresa;
            db.Usuario.Add(usuario);
            db.SaveChanges();


            return Ok(usuario);
        }
        /// <summary>
        /// Modifica un Usuario Empresarial por su id.
        /// </summary>
        /// <returns>Ejemplo de solicitud.</returns>
        [Route("api/PutEmpresarial")]
        public IHttpActionResult PutEmpresarial(Usuario_Empresarial usuario)
        {
            int id = usuario.Id;
            if (usuario == null)
            {
                return BadRequest("El usuario no puede ser nulo.");
            }
            var empresa = db.Empresa.Find(usuario.Empresa_Id);
            if (empresa == null)
            {
                return BadRequest("La empresa especificada no existe.");
            }
            usuario.Empresa = empresa;
            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(usuario);
        }
        public IHttpActionResult Get(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
        public IHttpActionResult Delete(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return Ok(usuario);
        }

    }
}

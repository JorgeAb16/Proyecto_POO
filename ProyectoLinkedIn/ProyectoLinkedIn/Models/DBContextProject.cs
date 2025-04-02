using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoLinkedIn.Models
{
    public class DBContextProject : DbContext
    {
        public DBContextProject() : base("MyDbConnectionString")
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Conexion> Conexion { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Experiencia> Experiencia { get; set; }
        public DbSet<Formacion_Academica> FormacionAcademica { get; set; }
        public DbSet<Habilidades> Habilidades { get; set; }
        public DbSet<Mensaje> Mensaje { get; set; }
        public DbSet<Notificacion> Notificacion { get; set; }
        public DbSet<Publicacion> Publicacion { get; set; }
        public DbSet<Reaccion> Reaccion { get; set; }
        public DbSet<Vacante> Vacante { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Usuario>()
                .Map<Usuario_Normal>(m => m.Requires("TipoUsuario").HasValue("Normal"))
                .Map<Usuario_Empresarial>(m => m.Requires("TipoUsuario").HasValue("Empresarial"))
                .Map<Administrador>(m => m.Requires("TipoUsuario").HasValue("Admin"));

            base.OnModelCreating(modelBuilder);
             
        }

    }
}
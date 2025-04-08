using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoLinkedinMVC.Models
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext() : base("name=AuthConnection") { }

        public DbSet<Usuario> Usuarios { get; set; }
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
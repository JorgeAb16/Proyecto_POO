using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedinMVC.Models
{
	public class Amigos
	{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto { get; set; }
        public string TipoConexion { get; set; }
        public Amigos() { }
    }
}
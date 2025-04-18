using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedinMVC.Models
{
    public abstract class Usuario
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _telefono;
        private string _correo;

        public Usuario()
        {

        }

        public Usuario(int id, string nombre, string apellido, string telefono, string correo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Correo = correo;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Contrasena { get; set; }
        public string NombreCompleto { get; set; }
    }
}
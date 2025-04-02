using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedIn.Models
{
    public class Conexion
    {
        private int id;
        private Usuario usuario1;
        private Usuario usuario2;
        private string conexion;

        public int Id { get => id; set => id = value; }
        public Usuario Usuario1 { get => usuario1; set => usuario1 = value; }
        public Usuario Usuario2 { get => usuario2; set => usuario2 = value; }
        public string _Conexion { get => conexion; set => conexion = value; }

        public Conexion() { }

        public Conexion(int id, Usuario usuario1, Usuario usuario2, string conexion)
        {
            Id = id;
            Usuario1 = usuario1;
            Usuario2 = usuario2;
            _Conexion = conexion;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedinMVC.Models
{
    public class Conexion
    {
        private int id;
        private int usuario1;
        private int usuario2;
        private string conexion;

        public int Id { get => id; set => id = value; }
        public int Usuario1 { get => usuario1; set => usuario1 = value; }
        public int Usuario2 { get => usuario2; set => usuario2 = value; }
        public string _Conexion { get => conexion; set => conexion = value; }

        public Conexion() { }

        public Conexion(int id, int usuario1, int usuario2, string conexion)
        {
            Id = id;
            Usuario1 = usuario1;
            Usuario2 = usuario2;
            _Conexion = conexion;
        }
    }
}
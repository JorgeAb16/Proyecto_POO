using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedIn.Models
{
    public class Habilidades
    {
        private int id;
        private string nombre;
        private string descripcion;
        private int usuarioId;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Usuario_Id { get => usuarioId; set => usuarioId = value; }

        public Habilidades()
        {

        }

        public Habilidades(int id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
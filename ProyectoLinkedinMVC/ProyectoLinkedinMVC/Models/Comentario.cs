using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedinMVC.Models
{
    public class Comentario
    {
        private int _id;
        private int _usuario;
        private int publicacion;
        private string _contenido;
        private DateTime _fechapublicacion;
        public Comentario()
        {

        }

        public Comentario(int id, string contenido, DateTime fechapublicacion, int usuario)
        {
            Id = id;
            Contenido = contenido;
            Fechapublicacion = fechapublicacion;
            UsuarioId = usuario;
        }

        public int Id { get => _id; set => _id = value; }
        public string Contenido { get => _contenido; set => _contenido = value; }
        public DateTime Fechapublicacion { get => _fechapublicacion; set => _fechapublicacion = value; }
        public int UsuarioId { get => _usuario; set => _usuario = value; }
        public int PublicacionId { get => publicacion; set => publicacion = value; }
    }
}
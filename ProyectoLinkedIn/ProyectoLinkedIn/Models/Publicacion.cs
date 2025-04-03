using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedIn.Models
{
    public class Publicacion
    {
        private int _id;
        private int _usuario;
        private string _titulo;
        private string _contenido;
        private DateTime _fechapublicacion;

        public Publicacion()
        {
          
        }


        public Publicacion(int id, string titulo, string contenido, DateTime fechapublicacion, int usuario)
        {
            Id = id;
            Titulo = titulo;
            Contenido = contenido;
            Fechapublicacion = fechapublicacion;
            UsuarioId = usuario;
    
        }

        public int Id { get => _id; set => _id = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Contenido { get => _contenido; set => _contenido = value; }
        public DateTime Fechapublicacion { get => _fechapublicacion; set => _fechapublicacion = value; }
        public int UsuarioId { get => _usuario; set => _usuario = value; }
       
    }
}
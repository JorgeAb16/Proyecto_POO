using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedIn.Models
{
    public class Publicacion
    {
        private int _id;
        private Usuario _usuario;
        private string _titulo;
        private string _contenido;
        private List<Comentario> comentarios;
        private List<Reaccion> reacciones;
        private DateTime _fechapublicacion;

        public Publicacion()
        {
            comentarios = new List<Comentario>();
            reacciones = new List<Reaccion>();
        }


        public Publicacion(int id, string titulo, string contenido, DateTime fechapublicacion, Usuario usuario, List<Comentario> comentarios, List<Reaccion> reacciones)
        {
            Id = id;
            Titulo = titulo;
            Contenido = contenido;
            Fechapublicacion = fechapublicacion;
            Usuario = usuario;
            Comentarios = comentarios;
            Reacciones = reacciones;
        }

        public int Id { get => _id; set => _id = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Contenido { get => _contenido; set => _contenido = value; }
        public DateTime Fechapublicacion { get => _fechapublicacion; set => _fechapublicacion = value; }
        public Usuario Usuario { get => _usuario; set => _usuario = value; }
        public List<Comentario> Comentarios { get => comentarios; set => comentarios = value; }
        public List<Reaccion> Reacciones { get => reacciones; set => reacciones = value; }
        
        public void AgregarComentario(Comentario comentario)
        {
            comentarios.Add(comentario);
        }
        public void AgregarReaccion(Reaccion reaccion)
        {
            reacciones.Add(reaccion);
        }
    }
}
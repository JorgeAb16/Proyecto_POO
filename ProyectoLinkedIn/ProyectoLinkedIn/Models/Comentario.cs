using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedIn.Models
{
    public class Comentario
	{
        private int _id;
        private Usuario _usuario;
        private string _contenido;
        private List<Reaccion> _reacciones;
        private DateTime _fechapublicacion;
        public Comentario()
        {
            _reacciones = new List<Reaccion>();

        }

        public Comentario(int id, string contenido, DateTime fechapublicacion, Usuario usuario, List<Reaccion> reacciones)
        {
            Id = id;
            Contenido = contenido;
            Fechapublicacion = fechapublicacion;
            Usuario = usuario;
            Reacciones = reacciones;
        }

        public int Id { get => _id; set => _id = value; }
        public string Contenido { get => _contenido; set => _contenido = value; }
        public DateTime Fechapublicacion { get => _fechapublicacion; set => _fechapublicacion = value; }
        public Usuario Usuario { get => _usuario; set => _usuario = value; }
        public List<Reaccion> Reacciones { get => _reacciones; set => _reacciones = value; }
    }
}
//Nada :]
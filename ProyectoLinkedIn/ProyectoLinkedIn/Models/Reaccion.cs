using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedIn.Models
{
    public class Reaccion
    {
        private int _id;
        private string _nombre;
        private string _contenido;
        private int _usuarioID;
        private Usuario _usuario;
        private int _comentarioID;
        private Comentario _comentario;
        private int _publicacionID;
        private Publicacion _publicacion;
        public Reaccion()
        {

        }

        public Reaccion(int id, string nombre, string contenido, Usuario usuario, int usuarioID, int comentarioID, Comentario comentario, int publicacionID, Publicacion publicacion)
        {
            Id = id;
            Nombre = nombre;
            Contenido = contenido;
            Usuario = usuario;
            UsuarioID = usuarioID;
            ComentarioID = comentarioID;
            Comentario = comentario;
            PublicacionID = publicacionID;
            Publicacion = publicacion;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Contenido { get => _contenido; set => _contenido = value; }
        [JsonIgnore]
        public Usuario Usuario { get => _usuario; set => _usuario = value; }
        public int UsuarioID { get => _usuarioID; set => _usuarioID = value; }
        public int ComentarioID { get => _comentarioID; set => _comentarioID = value; }
        [JsonIgnore]
        public Comentario Comentario { get => _comentario; set => _comentario = value; }
        public int PublicacionID { get => _publicacionID; set => _publicacionID = value; }
        [JsonIgnore]
        public Publicacion Publicacion { get => _publicacion; set => _publicacion = value; }
    }
}
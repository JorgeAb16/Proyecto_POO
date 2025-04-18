using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedinMVC.Models
{
    public class Reaccion
    {
        private int _id;
        private string _nombre;
        private string _contenido;
        private int _usuarioID;
        private int _comentarioID;
        private int _publicacionID;

        public Reaccion()
        {

        }

        public Reaccion(int id, string nombre, string contenido, int usuarioID, int comentarioID, int publicacionID)
        {
            Id = id;
            NombreReaccion = nombre;
            Contenido = contenido;
            UsuarioID = usuarioID;
            ComentarioID = comentarioID;
            PublicacionID = publicacionID;
        }

        public int Id { get => _id; set => _id = value; }
        public string NombreReaccion { get => _nombre; set => _nombre = value; }
        public string Contenido { get => _contenido; set => _contenido = value; }
        public int UsuarioID { get => _usuarioID; set => _usuarioID = value; }
        public int ComentarioID { get => _comentarioID; set => _comentarioID = value; }
        public int PublicacionID { get => _publicacionID; set => _publicacionID = value; }

        public string NombreUsuario { get; set; }
        public string ContenidoComentario { get; set; }
        public string publicacionTitulo { get; set; }

    }
}
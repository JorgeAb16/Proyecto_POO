using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedIn.Models
{
    public class Experiencia
    {
        private int _id;
        private int _usuarioID;
        private Usuario _usuario;
        private string _empresa;
        private string _cargo;
        private DateTime _fecha_inicio;
        private DateTime _fecha_fin;

        public Experiencia()
        {

        }

        public Experiencia(int id, string cargo, DateTime fecha_inicio, DateTime fecha_fin, Usuario usuario, string empresa, int usuarioID)
        {
            Id = id;
            Cargo = cargo;
            Fecha_inicio = fecha_inicio;
            Fecha_fin = fecha_fin;
            Usuario = usuario;
            Empresa = empresa;
            UsuarioID = usuarioID;
        }

        public int Id { get => _id; set => _id = value; }
        public string Cargo { get => _cargo; set => _cargo = value; }
        public DateTime Fecha_inicio { get => _fecha_inicio; set => _fecha_inicio = value; }
        public DateTime Fecha_fin { get => _fecha_fin; set => _fecha_fin = value; }
        [JsonIgnore]
        public Usuario Usuario { get => _usuario; set => _usuario = value; }
        public string Empresa { get => _empresa; set => _empresa = value; }
        public int UsuarioID { get => _usuarioID; set => _usuarioID = value; }
    }
}
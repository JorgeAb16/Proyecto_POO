using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedIn.Models
{
    public class Mensaje
    {
        private int _id;
        
        private Usuario _remitente;
        private Usuario _destinatario;
        private string _contenido;
        private DateTime _fechadeenvio;

        public Mensaje()
        {

        }

        public Mensaje(int id, string contenido, DateTime fechadeenvio, Usuario remitente, Usuario destinatario)
        {
            Id = id;
            Contenido = contenido;
            Fechadeenvio = fechadeenvio;
            Remitente = remitente;
            Destinatario = destinatario;
        }

        public int Id { get => _id; set => _id = value; }
        public string Contenido { get => _contenido; set => _contenido = value; }
        public DateTime Fechadeenvio { get => _fechadeenvio; set => _fechadeenvio = value; }
        public int Remitente_Id { get; set; }
        [JsonIgnore]
        public Usuario Remitente { get => _remitente; set => _remitente = value; }
        public int Destinatario_Id { get; set; }
        [JsonIgnore]
        public Usuario Destinatario { get => _destinatario; set => _destinatario = value; }
    }
}
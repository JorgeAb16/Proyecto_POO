using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedinMVC.Models
{
    public class Mensaje
    {
        private int _id;
        private int remitenteId;
        private int destinatarioId;
        private string _contenido;
        private DateTime _fechadeenvio;

        public Mensaje()
        {

        }

        public Mensaje(int id, string contenido, DateTime fechadeenvio)
        {
            Id = id;
            Contenido = contenido;
            Fechadeenvio = fechadeenvio;

        }

        public int Id { get => _id; set => _id = value; }
        public string Contenido { get => _contenido; set => _contenido = value; }
        public DateTime Fechadeenvio { get => _fechadeenvio; set => _fechadeenvio = value; }
        public int Remitente_Id { get => remitenteId; set => remitenteId = value; }
        public int Destinatario_Id { get => destinatarioId; set => destinatarioId = value; }
        public string Remitente { get; set; }
        public string Destinatario { get; set; }
    }
}
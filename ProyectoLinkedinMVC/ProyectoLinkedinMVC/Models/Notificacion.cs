using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedinMVC.Models
{
    public class Notificacion
    {
        private int _id;
        private string _mensaje;
        private int _destinatario;
        private DateTime _fechaenvio;
        public Notificacion()
        {

        }

        public Notificacion(int id, string mensaje, DateTime fechaenvio, int destinatario)
        {
            Id = id;
            Mensaje = mensaje;
            Fechaenvio = fechaenvio;
            DestinatarioId = destinatario;
        }

        public int Id { get => _id; set => _id = value; }
        public string Mensaje { get => _mensaje; set => _mensaje = value; }
        public DateTime Fechaenvio { get => _fechaenvio; set => _fechaenvio = value; }
        public int DestinatarioId { get => _destinatario; set => _destinatario = value; }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedIn.Models
{
    public class Usuario_Normal : Usuario
    {
        private string _ubicacion;
        public Usuario_Normal()
        {
       

        }

        public Usuario_Normal(string ubicacion)
        {
            Ubicacion = ubicacion;
            
        }

        public string Ubicacion { get => _ubicacion; set => _ubicacion = value; }
       
        
    }
}
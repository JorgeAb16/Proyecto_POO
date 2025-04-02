using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedIn.Models
{
    public class Administrador : Usuario
    {

        private int _clave;
        public Administrador()
        {

        }

        public Administrador(int clave, int id, string nombre, string apellido, string telefono, string correo) : base(id, nombre, apellido, telefono, correo)
        {

            Clave = clave;
        }


        public int Clave { get => _clave; set => _clave = value; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedinMVC.Models
{
    public class Empresa
    {
        private int _id;
        private string _nombre;
        private string _descripcion;
        private string _industria;
        private string _ubicacion;
        private string _sitioweb;

        public Empresa()
        {

        }

        public Empresa(int id, string nombre, string descripcion, string industria, string ubicacion, string sitioweb)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Industria = industria;
            Ubicacion = ubicacion;
            Sitioweb = sitioweb;

        }

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Industria { get => _industria; set => _industria = value; }
        public string Ubicacion { get => _ubicacion; set => _ubicacion = value; }
        public string Sitioweb { get => _sitioweb; set => _sitioweb = value; }
    }
}
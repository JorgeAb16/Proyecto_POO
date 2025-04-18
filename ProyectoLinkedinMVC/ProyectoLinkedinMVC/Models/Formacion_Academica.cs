﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedinMVC.Models
{
    public class Formacion_Academica
    {
        private int _id;
        private int _usuarioID;
        private string _titulo;
        private string _grado;
        private string _descripcion;
        private DateTime _fecha_adquisicion;
        private string _institucion_educativa;
        public Formacion_Academica()
        {

        }

        public Formacion_Academica(int id, string titulo, string grado, string descripcion, DateTime fecha_adquisicion, string institucion_educativa, int usuarioID)
        {
            Id = id;
            Titulo = titulo;
            Grado = grado;
            Descripcion = descripcion;
            FechaAdquisicion = fecha_adquisicion;
            InstitucionEducativa = institucion_educativa;
            UsuarioID = usuarioID;
        }

        public int Id { get => _id; set => _id = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Grado { get => _grado; set => _grado = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public DateTime FechaAdquisicion { get => _fecha_adquisicion; set => _fecha_adquisicion = value; }
        public string InstitucionEducativa { get => _institucion_educativa; set => _institucion_educativa = value; }
        public int UsuarioID { get => _usuarioID; set => _usuarioID = value; }

        public string UsuarioNombre { get; set; }
    }
}
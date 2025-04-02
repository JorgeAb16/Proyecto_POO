using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedIn.Models
{
	public class Vacante
	{
        private int _id;
        private string _titulo;
        private string _descripcion;
        private string _requisitos;
        private double salario;
        private string ubicacion;
        private Empresa _empresa;
        public Vacante()
        {

        }

        public Vacante(int id, string titulo, string descripcion, string requisitos, double salario, string ubicacion, Empresa empresa)
        {
            Id = id;
            Titulo = titulo;
            Descripcion = descripcion;
            Requisitos = requisitos;
            Salario = salario;
            Ubicacion = ubicacion;
            Empresa = empresa;
        }

        public int Id { get => _id; set => _id = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Requisitos { get => _requisitos; set => _requisitos = value; }
        public double Salario { get => salario; set => salario = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public Empresa Empresa { get => _empresa; set => _empresa = value; }
    }
}
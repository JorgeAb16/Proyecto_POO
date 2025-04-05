using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedinMVC.Models
{
    public class Usuario_Empresarial : Usuario
    {
        private int empresa_Id;
        public Usuario_Empresarial()
        {

        }
        public Usuario_Empresarial(int id, string nombre, string apellido, string telefono, string correo, int empresa_Id) : base(id, nombre, apellido, telefono, correo)
        {
            Empresa_Id = empresa_Id;
        }

        public int Empresa_Id { get => empresa_Id; set => empresa_Id = value; }
    }
}
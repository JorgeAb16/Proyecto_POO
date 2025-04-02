using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLinkedIn.Models
{
    public class Usuario_Empresarial : Usuario
    {
        private int empresa_Id;
        private Empresa _empresa;
        public Usuario_Empresarial()
        {

        }
        public Usuario_Empresarial(Empresa empresa, int id, string nombre, string apellido, string telefono, string correo, int empresa_Id) : base(id, nombre, apellido, telefono, correo)
        {
            Empresa = empresa;
            Empresa_Id = empresa_Id;
        }
        [JsonIgnore]
        public Empresa Empresa { get => _empresa; set => _empresa = value; }
        public int Empresa_Id { get => empresa_Id; set => empresa_Id = value; }
    }
}
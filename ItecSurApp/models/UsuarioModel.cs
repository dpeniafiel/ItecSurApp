using System;
using System.Collections.Generic;
using System.Text;

namespace ItecSurApp.models
{
    public class UsuarioModel
    {

        public int codigo { get; set; }
        public int perfil_codigo { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string identificacion { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string correo { get; set; }
        public string celular { get; set; }
        public string direccion { get; set; }
        public string fotografia { get; set; }
        public string estado { get; set; }

    }
}

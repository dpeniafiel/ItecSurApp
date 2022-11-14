using System;
using System.Collections.Generic;
using System.Text;

namespace ItecSurApp.models
{
    public class PermisoModel
    {
        public int codigo { get; set; }
        public int perfil_codigo { get; set; }
        public string opcion_codigo { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
    }
}

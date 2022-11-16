using System;
using System.Collections.Generic;
using System.Text;

namespace ItecSurApp.models
{
    public class InscripcionModel
    {
        public int codigo { get; set; }
        public int usuario_codigo { get; set; }
        public int jornada_codigo { get; set; }
        public string fecha_inscripcion { get; set; }
        public string estado { get; set; }
    }
}

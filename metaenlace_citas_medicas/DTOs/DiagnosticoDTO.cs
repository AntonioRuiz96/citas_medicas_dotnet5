using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metaenlace_citas_medicas.DTOs
{
    public class DiagnosticoDTO
    {
        public int diagnosticoID { get; set; }

        public string valoracionEspecialista { get; set; }

        public string enfermedad { get; set; }

        public int citaID { get; set; }
    }
}

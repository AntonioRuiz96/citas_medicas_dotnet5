using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metaenlace_citas_medicas.DTOs
{
    public class CitaDTO
    {
        public int citaID { get; set; }

        public DateTime fechaHora { get; set; }

        public string motivoCita { get; set; }

        public int pacienteUserID { get; set; }

        public int medicoUserID { get; set; }

        public int diagnosticoDiagnosticoID { get; set; }

    }
}

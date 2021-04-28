using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace metaenlace_citas_medicas.Entities
{
    public class Cita
    {
        [Key]
        public int citaID { get; set; }

        public DateTime fechaHora { get; set; }

        public string motivoCita { get; set; }

        public int pacienteUserID { get; set; }
        public Paciente paciente { get; set; }

        public int medicoUserID { get; set; }
        public Medico medico { get; set; }

        public Diagnostico diagnostico { get; set; }


    }

}
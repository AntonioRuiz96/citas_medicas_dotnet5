using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace metaenlace_citas_medicas.Entities
{
    public class Diagnostico
    {
        [Key]
        public int diagnosticoID { get; set; }

        public string valoracionEspecialista { get; set; }

        public string enfermedad { get; set; }

        public int citaID { get; set; }
        public Cita cita { get; set; }

    }
}

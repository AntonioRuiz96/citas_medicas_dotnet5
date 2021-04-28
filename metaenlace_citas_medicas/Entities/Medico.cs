using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metaenlace_citas_medicas.Entities
{
    public class Medico : Usuario
    {

        public string numColegiado { get; set; }

        public ICollection<Paciente> pacientes { get; set; } = new List<Paciente>();

        public ICollection<Cita> citas { get; set; } = new List<Cita>();

    }
}

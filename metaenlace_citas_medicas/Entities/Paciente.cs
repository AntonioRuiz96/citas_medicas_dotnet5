using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metaenlace_citas_medicas.Entities
{
    public class Paciente : Usuario
    {
        public string NSS { get; set; }

        public string numTarjeta { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public ICollection<Medico> medicos { get; set; } = new List<Medico>();

        public ICollection<Cita> Citas { get; set; } = new List<Cita>();

    }
}

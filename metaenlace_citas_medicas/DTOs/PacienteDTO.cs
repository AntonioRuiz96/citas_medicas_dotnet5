using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metaenlace_citas_medicas.DTOs
{
    public class PacienteDTO
    {
        public int userID { get; set; }

        public string usuario { get; set; }

        public string nombre { get; set; }

        public string apellidos { get; set; }

        public string clave { get; set; }

        public string NSS { get; set; }

        public string numTarjeta { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public IList<int> medicosUserID { get; set; }
        public IList<int> CitasCitaID { get; set; }

    }
}

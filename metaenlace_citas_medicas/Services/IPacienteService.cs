using metaenlace_citas_medicas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metaenlace_citas_medicas.Services
{
    public interface IPacienteService
    {
        public IEnumerable<PacienteDTO> GetAll();

        public PacienteDTO Get(int id);

        public PacienteDTO Put(PacienteDTO pacienteDTO);

        public Boolean Delete(int id);
    }
}

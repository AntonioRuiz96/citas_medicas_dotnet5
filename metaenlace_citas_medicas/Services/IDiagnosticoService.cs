using metaenlace_citas_medicas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metaenlace_citas_medicas.Services
{
    public interface IDiagnosticoService
    {
        public IEnumerable<DiagnosticoDTO> GetAll();

        public DiagnosticoDTO Get(int id);

        public DiagnosticoDTO Put(DiagnosticoDTO diagnosticoDTO);

        public Boolean Delete(int id);
    }
}

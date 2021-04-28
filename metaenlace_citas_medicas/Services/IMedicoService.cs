using metaenlace_citas_medicas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metaenlace_citas_medicas.Services
{
    public interface IMedicoService
    {
        public IEnumerable<MedicoDTO> GetAll();

        public MedicoDTO Get(int id);

        public MedicoDTO Put(MedicoDTO medicoDTO);

        public Boolean Delete(int id);
    }
}

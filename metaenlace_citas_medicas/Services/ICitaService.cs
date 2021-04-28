using metaenlace_citas_medicas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metaenlace_citas_medicas.Services
{
    public interface ICitaService
    {
        public IEnumerable<CitaDTO> GetAll();

        public CitaDTO Get(int id);

        public Task<CitaDTO> Put(CitaDTO citaDTO);

        public Boolean Delete(int id);
    }
}
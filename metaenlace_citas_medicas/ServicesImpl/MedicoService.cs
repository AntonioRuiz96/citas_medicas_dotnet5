using AutoMapper;
using metaenlace_citas_medicas.DTOs;
using metaenlace_citas_medicas.Entities;
using metaenlace_citas_medicas.Repositories;
using metaenlace_citas_medicas.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metaenlace_citas_medicas.ServicesImpl
{
    public class MedicoService : IMedicoService
    {
        protected citasMedicasDbContext citasMedicasDbContext;
        protected IMapper autoMapper;
        public MedicoService(citasMedicasDbContext dbContext, IMapper autoMapper)
        {
            this.citasMedicasDbContext = dbContext;
            this.autoMapper = autoMapper;
        }

        public bool Delete(int id)
        {
            Medico user = citasMedicasDbContext.Medicos.Find(id);
            if (user is null)
            {
                return false;
            }
            else
            {
                citasMedicasDbContext.Remove(user);
                citasMedicasDbContext.SaveChanges();
                return true;
            }
        }

        public MedicoDTO Get(int id)
        {
            var medico = MapToDTO(citasMedicasDbContext.Medicos.Include(m => m.pacientes).Include(m => m.citas).Single(m => m.userID == id));

            if (medico is null)
            {
                return null;
            }
            else
            { return medico; }

        }

        public IEnumerable<MedicoDTO> GetAll()
        {
            IEnumerable <Medico> medicos = citasMedicasDbContext.Medicos.Include(m => m.pacientes).Include(m => m.citas).ToList();
            return medicos.Select(m => MapToDTO(m)).ToList();
        }
        private MedicoDTO MapToDTO(Medico medico)
        {
            MedicoDTO medicoDTO = autoMapper.Map<MedicoDTO>(medico);

            if (medico.pacientes is not null)
            {
                medicoDTO.pacientesUserID = medico.pacientes.Select(p => p.userID).ToList();
            }


            if (medico.citas is not null)
            {
                medicoDTO.CitasCitaID = medico.citas.Select(c => c.citaID).ToList();
            }

            return medicoDTO;
        }

        public MedicoDTO Put(MedicoDTO medicoDTO)
        {
            Medico medico = new()
            {
                usuario = medicoDTO.usuario,
                nombre = medicoDTO.nombre,
                apellidos = medicoDTO.apellidos,
                clave = medicoDTO.clave,
                numColegiado = medicoDTO.numColegiado,
                citas = new List<Cita>()
            };
            citasMedicasDbContext.Medicos.Add(medico);
            citasMedicasDbContext.SaveChanges();

            return medicoDTO;
        }
    }
}

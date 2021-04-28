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
    public class CitaService : ICitaService
    {
        protected citasMedicasDbContext citasMedicasDbContext;
        protected IMapper autoMapper;
        public CitaService(citasMedicasDbContext dbContext, IMapper autoMapper)
        {
            this.citasMedicasDbContext = dbContext;
            this.autoMapper = autoMapper;
        }

        public bool Delete(int id)
        {
            Cita user = citasMedicasDbContext.Citas.Find(id);
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

        public CitaDTO Get(int id)
        {
            var cita = autoMapper.Map<CitaDTO>(citasMedicasDbContext.Citas.Find(id));

            if (cita is null)
            {
                return null;
            }
            else
            { return cita; }

        }

        public IEnumerable<CitaDTO> GetAll()
        {
            return autoMapper.Map<IEnumerable<CitaDTO>>(citasMedicasDbContext.Citas.Include(c => c.diagnostico));
        }

        public async Task<CitaDTO> Put(CitaDTO citaDTO)
        {
            Medico m = await citasMedicasDbContext.Medicos.FindAsync(citaDTO.medicoUserID);

            if (m is null)
            {
                return null;
            }

            Paciente p = await citasMedicasDbContext.Pacientes.FindAsync(citaDTO.pacienteUserID);

            if (p is null)
            {
                return null;
            }

            Cita cita = new()
            {
                motivoCita = citaDTO.motivoCita,
                medicoUserID = m.userID,
                medico = m,
                pacienteUserID = p.userID,
                paciente = p
            };

            p.Citas.Add(cita);
            m.citas.Add(cita);
            citasMedicasDbContext.Entry(p).State = EntityState.Modified;
            citasMedicasDbContext.Entry(m).State = EntityState.Modified;
            await citasMedicasDbContext.SaveChangesAsync();

            return citaDTO;
        }
    }
}

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
    public class PacienteService : IPacienteService
    {
        protected citasMedicasDbContext citasMedicasDbContext;
        protected IMapper autoMapper;
        public PacienteService(citasMedicasDbContext dbContext, IMapper autoMapper)
        {
            this.citasMedicasDbContext = dbContext;
            this.autoMapper = autoMapper;
        }

        public bool Delete(int id)
        {
            Paciente user = citasMedicasDbContext.Pacientes.Find(id);
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

        public PacienteDTO Get(int id)
        {
            var paciente = MapToDTO(citasMedicasDbContext.Pacientes.Include(p => p.medicos).Include(p => p.Citas).Single(p => p.userID == id));

            if (paciente is null)
            {
                return null;
            }
            else
            { return paciente; }

        }

        public IEnumerable<PacienteDTO> GetAll()
        {
            IEnumerable<Paciente> pacientes = citasMedicasDbContext.Pacientes.Include(p => p.medicos).Include(p => p.Citas).ToList();
            return pacientes.Select(p => MapToDTO(p)).ToList();
        }

        private PacienteDTO MapToDTO(Paciente paciente)
        {
            PacienteDTO pacienteDTO = autoMapper.Map<PacienteDTO>(paciente);

            if (paciente.medicos is not null)
            {
                pacienteDTO.medicosUserID = paciente.medicos.Select(m => m.userID).ToList();
            }


            if (paciente.Citas is not null)
            {
                pacienteDTO.CitasCitaID = paciente.Citas.Select(c => c.citaID).ToList();
            }

            return pacienteDTO;
        }

        public PacienteDTO Put(PacienteDTO pacienteDTO)
        {
            IList<int> medicos = pacienteDTO.medicosUserID;
            ICollection<Medico> listaMedicos = new List<Medico>();

            foreach (int medico in medicos)
            {
                Medico m = citasMedicasDbContext.Medicos.Find(medico);
                if (m is null)
                {
                    return null;
                }
                else
                {
                    listaMedicos.Add(m);
                }
            }

            Paciente paciente = new()
            {
                usuario = pacienteDTO.usuario,
                nombre = pacienteDTO.nombre,
                apellidos = pacienteDTO.apellidos,
                clave = pacienteDTO.clave,
                NSS = pacienteDTO.NSS,
                numTarjeta = pacienteDTO.numTarjeta,
                Telefono = pacienteDTO.Telefono,
                Direccion = pacienteDTO.Direccion,
                medicos = listaMedicos
            };

            foreach (Medico medico in listaMedicos)
            {
                medico.pacientes.Add(paciente);
                citasMedicasDbContext.Entry(medico).State = EntityState.Modified;
            }

            citasMedicasDbContext.SaveChanges();
            return pacienteDTO;
        }
    }
}

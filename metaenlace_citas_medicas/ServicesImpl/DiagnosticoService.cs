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
    public class DiagnosticoService : IDiagnosticoService
    {
        protected citasMedicasDbContext citasMedicasDbContext;
        protected IMapper autoMapper;
        public DiagnosticoService(citasMedicasDbContext dbContext, IMapper autoMapper)
        {
            this.citasMedicasDbContext = dbContext;
            this.autoMapper = autoMapper;
        }

        public bool Delete(int id)
        {
            Diagnostico user = citasMedicasDbContext.Diagnosticos.Find(id);
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

        public DiagnosticoDTO Get(int id)
        {
            var diagnostico = autoMapper.Map<DiagnosticoDTO>(citasMedicasDbContext.Diagnosticos.Find(id));

            if (diagnostico is null)
            {
                return null;
            }
            else
            { return diagnostico; }

        }

        public IEnumerable<DiagnosticoDTO> GetAll()
        {
            return autoMapper.Map<IEnumerable<DiagnosticoDTO>>(citasMedicasDbContext.Diagnosticos);
        }

        public DiagnosticoDTO Put(DiagnosticoDTO diagnosticoDTO)
        {
            Cita c = citasMedicasDbContext.Citas.Find(diagnosticoDTO.citaID);

            if (c is null)
            {
                return null;
            }

            Diagnostico diagnostico = new()
            {
                valoracionEspecialista = diagnosticoDTO.valoracionEspecialista,
                enfermedad = diagnosticoDTO.enfermedad,
                citaID = c.citaID,
                cita = c
            };

            c.diagnostico = diagnostico;
            citasMedicasDbContext.Entry(c).State = EntityState.Modified;
            citasMedicasDbContext.SaveChanges();

            return diagnosticoDTO;
        }
    }
}

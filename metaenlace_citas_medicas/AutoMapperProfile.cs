using AutoMapper;
using metaenlace_citas_medicas.DTOs;
using metaenlace_citas_medicas.Entities;

namespace metaenlace_citas_medicas
{  
    public class AutoMapperProfile : Profile  
    {  
        public AutoMapperProfile()  //Pasar de DTO a entidad, y de entidad a DTO
        {   
            CreateMap<Usuario, UsuarioDTO>();

            CreateMap<UsuarioDTO, Usuario>();

            CreateMap<Paciente, PacienteDTO>();

            CreateMap<PacienteDTO, Paciente>();

            CreateMap<Medico, MedicoDTO>();

            CreateMap<MedicoDTO, Medico>();

            CreateMap<Diagnostico, DiagnosticoDTO>();

            CreateMap<DiagnosticoDTO, Diagnostico>();

            CreateMap<Cita, CitaDTO>();

            CreateMap<CitaDTO, Cita>();

        }  
    }  
}  

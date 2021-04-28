using AutoMapper;
using metaenlace_citas_medicas.DTOs;
using metaenlace_citas_medicas.Entities;
using metaenlace_citas_medicas.Repositories;
using metaenlace_citas_medicas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metaenlace_citas_medicas.ServicesImpl
{
    public class UsuarioService : IUsuarioService
    {
        protected citasMedicasDbContext citasMedicasDbContext;
        protected IMapper autoMapper;
        public UsuarioService(citasMedicasDbContext dbContext, IMapper autoMapper)
        {
            this.citasMedicasDbContext = dbContext;
            this.autoMapper = autoMapper;
        }

        public bool Delete(int id)
        {
            Usuario user = citasMedicasDbContext.Usuarios.Find(id);
            if (user is null)
            {
                return false;
            }
            else {
                citasMedicasDbContext.Remove(user);
                citasMedicasDbContext.SaveChanges();
                return true;
            }
        }

        public UsuarioDTO Get(int id)
        {
            var usuario = autoMapper.Map<UsuarioDTO>(citasMedicasDbContext.Usuarios.Find(id));

            if (usuario is null)
            {
                return null;
            }
            else 
            {return usuario;}
            
        }

        public IEnumerable<UsuarioDTO> GetAll()
        {
            return autoMapper.Map<IEnumerable<UsuarioDTO>>(citasMedicasDbContext.Usuarios);
        }

        public UsuarioDTO Put(UsuarioDTO usuarioDTO)
        {
            Usuario usuario = autoMapper.Map<Usuario>(usuarioDTO);
            citasMedicasDbContext.Usuarios.Add(usuario);
            citasMedicasDbContext.SaveChanges();
            return usuarioDTO;
        }
    }
}

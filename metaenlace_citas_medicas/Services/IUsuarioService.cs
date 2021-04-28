using metaenlace_citas_medicas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metaenlace_citas_medicas.Services
{
    public interface IUsuarioService
    {
        public IEnumerable<UsuarioDTO> GetAll();

        public UsuarioDTO Get(int id);

        public UsuarioDTO Put(UsuarioDTO usuarioDTO);

        public Boolean Delete(int id);
    }
}

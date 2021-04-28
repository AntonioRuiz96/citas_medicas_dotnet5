using metaenlace_citas_medicas.DTOs;
using metaenlace_citas_medicas.Entities;
using metaenlace_citas_medicas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metaenlace_citas_medicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        protected IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<UsuarioDTO> GetUsuarios()
        {
            return usuarioService.GetAll();
        }

        // GET: api/Usuario/1
        [HttpGet("{id}")]
        public ActionResult<UsuarioDTO> GetUsuario(int id)
        {
            var usuario = usuarioService.Get(id);

            if (usuario is null)
            {
                return NotFound();
            }
            else
            { return usuario; }

        }

        [HttpPost]
        public ActionResult<UsuarioDTO> CreateUsuario(UsuarioDTO usuarioDTO)
        {
            return usuarioService.Put(usuarioDTO);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            if (usuarioService.Delete(id))
            {
                return NoContent();
            }
            else 
            { return NotFound(); }
           
        }

    }
}

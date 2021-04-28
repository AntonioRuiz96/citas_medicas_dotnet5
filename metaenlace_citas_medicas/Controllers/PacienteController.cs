using metaenlace_citas_medicas.DTOs;
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
    public class PacienteController : ControllerBase
    {
        protected IPacienteService pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            this.pacienteService = pacienteService;
        }

        // GET: api/Paciente
        [HttpGet]
        public IEnumerable<PacienteDTO> GetPacientes()
        {
            return pacienteService.GetAll();
        }

        // GET: api/Paciente/1
        [HttpGet("{id}")]
        public ActionResult<PacienteDTO> GetPaciente(int id)
        {
            var paciente = pacienteService.Get(id);

            if (paciente is null)
            {
                return NotFound();
            }
            else
            { return paciente; }

        }

        [HttpPost]
        public ActionResult<PacienteDTO> CreatePaciente(PacienteDTO pacienteDTO)
        {
            return pacienteService.Put(pacienteDTO);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            if (pacienteService.Delete(id))
            {
                return NoContent();
            }
            else
            { return NotFound(); }

        }

    }
}

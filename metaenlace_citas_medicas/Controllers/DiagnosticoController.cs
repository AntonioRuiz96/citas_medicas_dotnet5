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
    public class DiagnosticoController : ControllerBase
    {
        protected IDiagnosticoService diagnosticoService;

        public DiagnosticoController(IDiagnosticoService diagnosticoService)
        {
            this.diagnosticoService = diagnosticoService;
        }

        // GET: api/Diagnostico
        [HttpGet]
        public IEnumerable<DiagnosticoDTO> GetDiagnosticos()
        {
            return diagnosticoService.GetAll();
        }

        // GET: api/Diagnostico/1
        [HttpGet("{id}")]
        public ActionResult<DiagnosticoDTO> GetDiagnostico(int id)
        {
            var diagnostico = diagnosticoService.Get(id);

            if (diagnostico is null)
            {
                return NotFound();
            }
            else
            { return diagnostico; }

        }

        [HttpPost]
        public ActionResult<DiagnosticoDTO> CreateDiagnostico(DiagnosticoDTO diagnosticoDTO)
        {
            return diagnosticoService.Put(diagnosticoDTO);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            if (diagnosticoService.Delete(id))
            {
                return NoContent();
            }
            else
            { return NotFound(); }

        }

    }
}

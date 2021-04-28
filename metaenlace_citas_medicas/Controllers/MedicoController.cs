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
    public class MedicoController : ControllerBase
    {
        protected IMedicoService medicoService;

        public MedicoController(IMedicoService medicoService)
        {
            this.medicoService = medicoService;
        }

        // GET: api/Medico
        [HttpGet]
        public IEnumerable<MedicoDTO> GetMedicos()
        {
            return medicoService.GetAll();
        }

        // GET: api/Medico/1
        [HttpGet("{id}")]
        public ActionResult<MedicoDTO> GetMedico(int id)
        {
            var medico = medicoService.Get(id);

            if (medico is null)
            {
                return NotFound();
            }
            else
            { return medico; }

        }

        [HttpPost]
        public ActionResult<MedicoDTO> CreateMedico(MedicoDTO medicoDTO)
        {
            return medicoService.Put(medicoDTO);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            if (medicoService.Delete(id))
            {
                return NoContent();
            }
            else
            { return NotFound(); }

        }

    }
}

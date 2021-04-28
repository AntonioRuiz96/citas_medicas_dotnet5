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
    public class CitaController : ControllerBase
    {
        protected ICitaService citaService;

        public CitaController(ICitaService citaService)
        {
            this.citaService = citaService;
        }

        // GET: api/Cita
        [HttpGet]
        public IEnumerable<CitaDTO> GetCitas()
        {
            return citaService.GetAll();
        }

        // GET: api/Cita/1
        [HttpGet("{id}")]
        public ActionResult<CitaDTO> GetCita(int id)
        {
            var cita = citaService.Get(id);

            if (cita is null)
            {
                return NotFound();
            }
            else
            { return cita; }

        }

        [HttpPost]
        public async Task<ActionResult<CitaDTO>> CreateCita(CitaDTO citaDTO)
        {
            return await citaService.Put(citaDTO);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            if (citaService.Delete(id))
            {
                return NoContent();
            }
            else
            { return NotFound(); }

        }

    }
}

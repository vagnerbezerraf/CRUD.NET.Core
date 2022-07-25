using CRUD.Net.Core.Business.DTOs.Requests;
using CRUD.Net.Core.Business.Notifications;
using CRUD.Net.Core.Business.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD.NET.Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] EventoService service)
        {
            var response = await service.GetAll();

            if (response.Count <= 0 || response == null)
                return NotFound("Eventos não encontrados");

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromServices] EventoService service, int id)
        {
            var response = await service.GetById(id);

            if (response == null)
                return NotFound("Evento não encontrados");

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] EventoService service, EventoRequest request)
        {

            var response = await service.Create(request);

            if (response == null)
                return BadRequest("Ocorreu um erro ao tentar criar o Evento");

            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromServices] EventoService service, EventoRequest request)
        {
            Result response = await service.Update(request);

            if (response.Status == false && response.Errors.Count > 0)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromServices] EventoService service, int id)
        {
            Result response = await service.Delete(id);

            if (response.Status == false && response.Errors.Count > 0)
                return BadRequest(response);

            return Ok(response);
        }
    }
}

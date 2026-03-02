using api_seguros.DTOs;
using Microsoft.AspNetCore.Mvc;
using Servicio;
using System.Threading.Tasks;

namespace api_seguros.Controllers
{
    [ApiController]
    [Route("api/polizas")]
    public class PolizasController : ControllerBase
    {
        private readonly IPolizaService _service;

        public PolizasController(IPolizaService service)
        {
            _service = service;
        }

        [HttpPost("emitir")]
        public async Task<IActionResult> Emitir([FromBody] EmitirPolizaRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // 400

            var poliza = await _service.EmitirPolizaAsync(request);

            if (poliza == null)
                return BadRequest(new
                {
                    mensaje = "No se pudo emitir la póliza. Verifique cliente, vehículo y coberturas."
                }); // 400

            return CreatedAtAction(
                nameof(GetById),
                new { id = poliza.Id },
                poliza
            ); // 201
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var polizas = await _service.ObtenerTodasAsync();

            return Ok(polizas); // 200
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest(new { mensaje = "Id inválido." }); // 400

            var poliza = await _service.ObtenerPorIdAsync(id);

            if (poliza == null)
                return NotFound(new { mensaje = "Póliza no encontrada." }); // 404

            return Ok(poliza); // 200
        }
    }
}

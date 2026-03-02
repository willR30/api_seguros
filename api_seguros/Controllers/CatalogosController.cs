using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositorio;
using System.Threading.Tasks;

namespace api_seguros.Controllers
{
    [ApiController]
    [Route("api/catalogos")]
    public class CatalogosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CatalogosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();

            if (clientes == null || !clientes.Any())
                return NotFound(new { mensaje = "No existen clientes registrados." }); // 404

            return Ok(clientes); // 200
        }

        [HttpGet("coberturas")]
        public async Task<IActionResult> GetCoberturas()
        {
            var coberturas = await _context.Coberturas.ToListAsync();

            if (coberturas == null || !coberturas.Any())
                return NotFound(new { mensaje = "No existen coberturas registradas." }); // 404

            return Ok(coberturas); // 200
        }
    }
}

using Repositorio.modelos;
using api_seguros.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicio
{
    public interface IPolizaService
    {
        Task<Poliza> EmitirPolizaAsync(EmitirPolizaRequest request);
        Task<List<Poliza>> ObtenerTodasAsync();
        Task<Poliza?> ObtenerPorIdAsync(int id);
    }
}

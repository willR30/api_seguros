using Microsoft.EntityFrameworkCore;
using Repositorio;
using Repositorio.modelos;
using Servicio;

public class PolizaService : IPolizaService
{
    private readonly ApplicationDbContext _context;

    public PolizaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Poliza> EmitirPolizaAsync(api_seguros.DTOs.EmitirPolizaRequest request)
    {

        var cliente = await _context.Clientes.FindAsync(request.ClienteId);
        if (cliente == null)
            throw new ArgumentException("El cliente no existe.");


        var vehiculo = await _context.Vehiculos
            .FirstOrDefaultAsync(v => v.Placa == request.Placa);

        if (vehiculo == null)
            throw new ArgumentException("El vehículo no existe. Debe registrarlo primero.");

        var coberturas = await _context.Coberturas
            .Where(c => request.CoberturasIds.Contains(c.Id))
            .ToListAsync();

        if (!coberturas.Any())
            throw new ArgumentException("Debe seleccionar al menos una cobertura válida.");

        
        var primaTotal = coberturas.Sum(c => c.MontoCobertura);

        
        var poliza = new Poliza
        {
            NumeroPoliza = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper(),
            ClienteId = request.ClienteId,
            VehiculoId = vehiculo.Id,
            FechaEmision = DateTime.UtcNow,
            SumaAsegurada = vehiculo.ValorComercial, 
            PrimaTotal = primaTotal
        };

        _context.Polizas.Add(poliza);
        await _context.SaveChangesAsync();

   
        foreach (var cobertura in coberturas)
        {
            _context.PolizaCoberturas.Add(new PolizaCobertura
            {
                PolizaId = poliza.Id,
                CoberturaId = cobertura.Id
            });
        }

        await _context.SaveChangesAsync();

        return poliza;
    }

    public async Task<List<Poliza>> ObtenerTodasAsync()
    {
        return await _context.Polizas
            .Include(p => p.Cliente)
            .Include(p => p.Vehiculo)
            .Include(p => p.PolizaCoberturas)
                .ThenInclude(pc => pc.Cobertura)
            .ToListAsync();
    }

    public async Task<Poliza?> ObtenerPorIdAsync(int id)
    {
        return await _context.Polizas
            .Include(p => p.Cliente)
            .Include(p => p.Vehiculo)
            .Include(p => p.PolizaCoberturas)
                .ThenInclude(pc => pc.Cobertura)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}

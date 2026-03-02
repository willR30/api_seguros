namespace api_seguros.DTOs
{
    public class EmitirPolizaRequest
    {
        public int ClienteId { get; set; }

        // Datos del carro
        public string Placa { get; set; }
        public int ModeloId { get; set; }
        public int Anio { get; set; }
        public decimal ValorComercial { get; set; }

        public List<int> CoberturasIds { get; set; }
    }

}

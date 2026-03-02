using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repositorio.modelos
{
    public class Poliza
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string NumeroPoliza { get; set; }

        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; }

        [ForeignKey(nameof(VehiculoId))]
        public Vehiculo Vehiculo { get; set; }

        public DateTime FechaEmision { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SumaAsegurada { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrimaTotal { get; set; }

        public ICollection<PolizaCobertura> PolizaCoberturas { get; set; }
    }
}

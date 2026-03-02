using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repositorio.modelos
{
    public class Vehiculo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Placa { get; set; }

        public int ModeloId { get; set; }

        [ForeignKey(nameof(ModeloId))]
        public Modelo Modelo { get; set; }

        public int Anio { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorComercial { get; set; }

        public ICollection<Poliza> Polizas { get; set; }
    }
}

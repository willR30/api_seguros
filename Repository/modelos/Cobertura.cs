using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repositorio.modelos
{
    public class Cobertura
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoCobertura { get; set; }

        public ICollection<PolizaCobertura> PolizaCoberturas { get; set; }
    }
}

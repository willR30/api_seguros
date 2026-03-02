using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repositorio.modelos
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string Identificacion { get; set; }

        [Required]
        [MaxLength(150)]
        public string Correo { get; set; }

        // Navigation
        public ICollection<Poliza> Polizas { get; set; }
    }
}

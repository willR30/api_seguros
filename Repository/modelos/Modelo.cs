using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repositorio.modelos
{
    public class Modelo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        public int MarcaId { get; set; }

        [ForeignKey(nameof(MarcaId))]
        public Marca Marca { get; set; }

        public ICollection<Vehiculo> Vehiculos { get; set; }
    }
}

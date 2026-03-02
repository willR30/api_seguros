using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.modelos
{
    public class PolizaCobertura
    {
        public int PolizaId { get; set; }
        public Poliza Poliza { get; set; }

        public int CoberturaId { get; set; }
        public Cobertura Cobertura { get; set; }
    }
}

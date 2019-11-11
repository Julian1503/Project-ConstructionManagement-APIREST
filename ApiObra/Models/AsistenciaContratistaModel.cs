using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class AsistenciaContratistaModel
    {
        public long ContratistaId { get; set; }
        public long JornalId { get; set; }
        public TimeSpan Entrada { get; set; }
        public TimeSpan Salida { get; set; }
        public string Observacion { get; set; }

    }
}

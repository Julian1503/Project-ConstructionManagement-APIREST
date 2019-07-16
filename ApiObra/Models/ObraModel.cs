using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class ObraModel
    {
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Observiacion { get; set; }
        public DateTime FechaEstimadaInicio { get; set; }
        public long PropietarioId { get; set; }
        public long EncargadoId { get; set; } //Persona
        public long? ZonaId { get; set; }
    }
}

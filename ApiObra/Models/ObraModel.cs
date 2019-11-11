using GestionObra.Constantes;
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
        public EstadoObra EstadoObra { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaEstimadaInicio { get; set; }
        public long? PropietarioId { get; set; }
        public long EncargadoId { get; set; } //Persona
        public long? ZonaId { get; set; }
    }
}

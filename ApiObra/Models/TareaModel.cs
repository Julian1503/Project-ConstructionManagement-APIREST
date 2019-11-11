using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionObra.Constantes;

namespace ApiObra.Models
{
    public class TareaModel
    {
        public long DescripcionTareaId { get; set; }
        public int NumeroOrden { get; set; }
        public string Observacion { get; set; }
        public EstadoTarea Estado { get; set; }
        public bool Precede { get; set; }
        public long ObraId { get; set; }
        public TimeSpan Duracion { get; set; }
        public TimeSpan TiempoEmpleado { get; set; }
    }
}

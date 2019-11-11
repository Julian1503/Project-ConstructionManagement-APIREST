using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class IngresoMaterialModel
    {
        public DateTime FechaIngreso { get; set; }
        public long MaterialId { get; set; }
        public long ObraId { get; set; }
        public long EncargadoId { get; set; }
        public int CantidadDevuelta { get; set; }
        public int Cantidad { get; set; }
    }
}

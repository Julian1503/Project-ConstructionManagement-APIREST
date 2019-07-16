using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class SalidaMaterialModel
    {
        public DateTime FechaEgreso { get; set; }
        public long MaterialId { get; set; }
        public long DeObraId { get; set; }
        public long ResponsableId { get; set; }
        public long ParaObraId { get; set; }
        public int Cantidad { get; set; }

    }
}

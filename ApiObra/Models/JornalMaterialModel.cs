using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class JornalMaterialModel
    {
        public long JornalId { get; set; }
        public int CantidadUsado { get; set; }
        public long MaterialId { get; set; }
    }
}

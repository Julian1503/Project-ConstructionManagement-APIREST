using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionObra.Constantes;

namespace ApiObra.Models
{
    public class RubroModel
    {
        public string Descripcion { get; set; }
        public TipoRubro TipoRubro { get; set; }
        public long Codigo { get; set; }
    }
}

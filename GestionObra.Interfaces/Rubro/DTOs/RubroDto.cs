using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;
using GestionObra.Interfaces.Base;

namespace GestionObra.Interfaces.Rubro.DTOs
{
    public class RubroDto : DtoBase
    {
        public string Descripcion { get; set; }
        public TipoRubro TipoRubro { get; set; }
        public long Codigo { get; set; }
    }
}
